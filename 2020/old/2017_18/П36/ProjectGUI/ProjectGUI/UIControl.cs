using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGUI
{
    public abstract class UIControl
    {
        public abstract void CalculateTextPosition();

        public UIControl()
        {
            _rect = new Rectangle();
        }

        public UIControl(int x, int y, int w, int h)
        {
            _rect = new Rectangle(x,y, w,h);
            _x = x;
            _y = y;
            _w = w;
            _h = h;
        }

        protected Rectangle _rect;

        protected Texture2D _tex;

        public Texture2D Tex
        {
            get { return _tex; }
            set { _tex = value; }
        }


        protected int _x;

        public int Left
        {
            get { return _x; }
            set
            {
                _x = value;
                _rect.X = _x;
                CalculateTextPosition();
            }
        }

        protected int _y;

        public int Top
        {
            get { return _y; }
            set
            {
                _y = value;
                _rect.Y = _y;
                CalculateTextPosition();
            }
        }

        protected int _w;

        public int Width
        {
            get { return _w; }
            set
            {
                _w = value;
                _rect.Width = _w;
                CalculateTextPosition();
            }
        }

        protected int _h;

        public int Height
        {
            get { return _h; }
            set
            {
                _h = value;
                _rect.Height = _h;
                CalculateTextPosition();
            }
        }

        abstract public void Draw(SpriteBatch batch);

        abstract public void Update(MouseState ms, MouseState prevMs);

    }
}
