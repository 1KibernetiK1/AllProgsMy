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
    public class ControllerMouseFollower
        : GameComponent
    {
        private Sprite _subject;

        public void Attach(Sprite sprite)
        {
            _subject = sprite;
        }

        public ControllerMouseFollower(Game game)
            :base(game)
        {
            game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var ms = Mouse.GetState();
            var msPos = new Vector2(ms.X, ms.Y);
            // определяем угол вектора 
            // subject - mouse
            Vector2 target = msPos - _subject.Pos;
            double alpha = Math.Atan2(target.Y, target.X);
            // поворачиваем объект на этот угол
            _subject.Angle = (float) (alpha + Math.PI/2);
            //===========================================
            if (ms.RightButton == ButtonState.Pressed)
            {
                Vector2 delta = target / 10;
                _subject.Move(delta);
            }
        }
    }
}
