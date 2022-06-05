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
    public enum StateButton
    {
        Regular,
        Active,
        Pressed
    }

    public class Button : Label
    {
        private StateButton _bState;

        private Texture2D _tex;

        

        public Texture2D BackTexture
        {
            get { return _tex; }
            set { _tex = value; }
        }

        public Button(string text) : base(text)
        {
            _tex = null;
            BackColor = Color.Transparent;
            _bState = StateButton.Regular;
            CalculateTextPos();
        }

        public override void OnClick(UIControl ctrl, Vector2 pos)
        {
            _bState = StateButton.Pressed;
            base.OnClick(ctrl, pos);
        }

        public override void OnMouseEnter(UIControl ctrl, Vector2 pos)
        {
            _bState = StateButton.Active;
            base.OnMouseEnter(ctrl, pos);
        }

        public override void OnMouseLeave(UIControl ctrl, Vector2 pos)
        {
            _bState = StateButton.Regular;
            base.OnMouseLeave(ctrl, pos);
        }

        private void DrawRegular(SpriteBatch batch)
        {
            if (_tex != null)
                batch.Draw(_tex, _bounds, Color.White);
            else
            {
                UISystem.FillRectangle(_bounds, BackColor);
            }
            batch.DrawString(_font, _text, _posText, ForeColor);
        }

        private void DrawActive(SpriteBatch batch)
        {
            if (_tex != null)
                batch.Draw(_tex, _bounds, Color.Red);
            else
            {
                float percent = 0.2f;
                int r = BackColor.R;
                int g = BackColor.G;
                int b = BackColor.B;
                r = (int)(r - r * percent);
                g = (int)(g - g * percent);
                b = (int)(b - b * percent);
                Color darkB = new Color(r,g,b);
                UISystem.FillRectangle(_bounds, darkB);
            }
            batch.DrawString(_font, _text, _posText, ForeColor);
        }

        private void DrawPressed(SpriteBatch batch)
        {
            int add = 2;
            Rectangle rect = 
                new Rectangle(_bounds.X + add,
                              _bounds.Y + add,
                              _bounds.Width  - 2*add,
                              _bounds.Height - 2*add);
            if (_tex != null)
                batch.Draw(_tex, rect, Color.DarkGray);
            else
            {
                float percent = 0.6f;
                int r = BackColor.R;
                int g = BackColor.G;
                int b = BackColor.B;
                r = (int)(r - r * percent);
                g = (int)(g - g * percent);
                b = (int)(b - b * percent);
                Color darkB = new Color(r, g, b);
                UISystem.FillRectangle(rect, darkB);
            }
            batch.DrawString(_font, _text, _posText, ForeColor);
        }

        public override void Draw(SpriteBatch batch)
        {
            switch (_bState)
            {
                case StateButton.Regular:
                    DrawRegular(batch);
                    break;
                case StateButton.Active:
                    DrawActive(batch);
                    break;
                case StateButton.Pressed:
                    DrawPressed(batch);
                    break;
            }
        }
    }
}
