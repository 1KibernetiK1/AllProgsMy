using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MgProjectFont
{
    abstract public class UIControl
    {
        protected bool _isSizedByHands;

        public event MouseEvent Click;
        public event MouseEvent MouseEnter;
        public event MouseEvent MouseLeave;

        virtual public void OnClick(UIControl ctrl, Vector2 pos)
        {
            Click?.Invoke(ctrl, pos);
        }

        virtual public void OnMouseEnter(UIControl ctrl, Vector2 pos)
        {
            MouseEnter?.Invoke(ctrl, pos);
        }

        virtual public void OnMouseLeave(UIControl ctrl, Vector2 pos)
        {
            MouseLeave?.Invoke(ctrl, pos);
        }

        public UIControl()
        {
            _bounds = new Rectangle(0,0,0,0);
            _isSizedByHands = false;
        }

        protected Rectangle _bounds;

        protected Vector2 _pos;

        public int Width
        {
            get { return _bounds.Width; }
            set
            {
                _bounds.Width = value;
                _isSizedByHands = true;
                CalculateTextPos();
            }
        }

        public int Height
        {
            get { return _bounds.Height; }
            set
            {
                _bounds.Height = value;
                _isSizedByHands = true;
                CalculateTextPos();
            }
        }

        public Vector2 Location
        {
            get { return _pos; }
            set
            {
                _pos = value;
                _bounds.X  =(int) _pos.X;
                _bounds.Y = (int) _pos.Y;
                CalculateTextPos();
            }
        }

        protected Vector2 _posText;
        protected SpriteFont _font;
        protected FontSize _fontSize;
        protected string _text;

        public FontSize FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
                _font = UISystem.Fonts[value];
                CalculateTextPos();
            }
        }

        protected void CalculateBounds()
        {
            Vector2 sz = _font.MeasureString(_text);
            _bounds.Width = (int)sz.X;
            _bounds.Height = (int)sz.Y;
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (!_isSizedByHands)
                    CalculateBounds();
                CalculateTextPos();
            }
        }

        virtual protected void CalculateTextPos()
        {
            int cx = _bounds.Right -
                     _bounds.Width / 2;
            int cy = _bounds.Bottom -
                     _bounds.Height / 2;
            Vector2 sz = _font.MeasureString(_text);
            _posText.X = cx - sz.X / 2;
            _posText.Y = cy - sz.Y / 2;
        }

        abstract public void Draw(SpriteBatch batch);

        public Rectangle GetBounds()
        {
            return _bounds;
        }
    }
}
