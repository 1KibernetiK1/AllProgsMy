using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGProjectUserControl
{
    public class ControllerKeyboard : GameComponent
    {
        private Sprite _subject;

        private float _speed;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public ControllerKeyboard(Game game)
            :base(game)
        {
            _speed = 2.0f;
            _subject = null;
            game.Components.Add(this);
        }

        /// <summary>
        /// Присоединяем к спрайту управление с клавиатуры
        /// </summary>
        /// <param name="sprite"></param>
        public void Attach(Sprite sprite)
        {
            _subject = sprite;
        }

        override public void Update(GameTime time)
        {
            var ks = Keyboard.GetState();
            var delta = new Vector2();
            if (ks.IsKeyDown(Keys.Q))
            {
                _subject.Angle -= 0.01f;
            }
            if (ks.IsKeyDown(Keys.E))
            {
                _subject.Angle += 0.01f;
            }
            if (ks.IsKeyDown(Keys.W))
            {
                // движение по курсу
                double dx = _speed * Math.Cos(_subject.Angle - Math.PI / 2);
                double dy = _speed * Math.Sin(_subject.Angle - Math.PI / 2);
                delta.X = (float)dx;
                delta.Y = (float)dy;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                delta.Y = _speed;
            }
            if (ks.IsKeyDown(Keys.A))
            {
                delta.X = -_speed;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                delta.X = _speed;
            }
            _subject.Move(delta);
        }
    }
}
