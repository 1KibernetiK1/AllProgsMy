using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLight
{
    public delegate void MouseEvent(Vector2 pos);

    public class ControllerMouse 
        : GameComponent
    {
        public event MouseEvent MouseDown;

        public event MouseEvent Click;

        private MouseState _prevMS;


        private Sprite _subject;

        public ControllerMouse(Game game)
            :base(game)
        {
            _subject = null;
            game.Components.Add(this);
        }

        public void Attach(Sprite sprite)
        {
            _subject = sprite;
        }

        public override void Update(GameTime gameTime)
        {
            var ms = Mouse.GetState();
            _subject.Pos = new Vector2(ms.X, ms.Y);
            base.Update(gameTime);
            if (ms.LeftButton == ButtonState.Pressed)
            {
                MouseDown?.Invoke(_subject.Pos);
            }
            if (ms.LeftButton == ButtonState.Released
                && _prevMS.LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(_subject.Pos);
            }
            _prevMS = ms;
        }
    }
}
