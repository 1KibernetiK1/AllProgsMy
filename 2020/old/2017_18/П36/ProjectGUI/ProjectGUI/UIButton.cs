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
    public delegate void MouseEvent(Vector2 pos);

    public class UIButton : UIControl
    {
        public event MouseEvent MouseEnter;
        public event MouseEvent MouseLeave;
        public event MouseEvent MouseLeftButtonDown;
        public event MouseEvent MouseRightButtonDown;
        public event MouseEvent MouseLeftButtonUp;
        public event MouseEvent MouseRightButtonUp;
        public event MouseEvent MouseLeftButtonClick;
        public event MouseEvent MouseRightButtonClick;

        protected UIButtonState _state;


        protected bool IsMouseOver = false;

        public UIButton(Texture2D tex, SpriteFont font) 
            : base(10,10, 100,50)
        {
            _state = UIButtonState.Normal;
            _tex = tex;
            _font = font;
            _text = "Text";
            TextHorizontalAlignment = 
                TextHorizontalAlignment.Center;
            TextVerticalAlignment =
                TextVerticalAlignment.Center;
            CalculateTextPosition();
        }

        protected SpriteFont _font;

        public SpriteFont Font
        {
            get { return _font; }
            set { _font = value; }
        }

        protected string _text;

        public string Text
        {
            get { return _text; }
            set {
                _text = value;
                CalculateTextPosition();
            }
        }

        private TextHorizontalAlignment _tha;
        public TextHorizontalAlignment TextHorizontalAlignment
        {
            get
            {
                return _tha;
            }
            set
            {
                _tha = value;
                CalculateTextPosition();
            }
        }

        protected TextVerticalAlignment _tva;
        public TextVerticalAlignment TextVerticalAlignment
        {
            get
            {
                return _tva;
            }
            set
            {
                _tva = value;
                CalculateTextPosition();
            }
        }


        public BackgroundStyle BackgroundStyle;

        protected Vector2 _posText;

        public override void CalculateTextPosition()
        {
            int x = 0, y = 0;

            Vector2 textSize = _font.MeasureString(_text);

            switch (TextHorizontalAlignment)
            {
                case TextHorizontalAlignment.Left:
                    x = _rect.Left;
                    break;
                case TextHorizontalAlignment.Center:
                    x = (int) (_rect.Right - _rect.Width / 2
                                - textSize.X / 2);
                    break;
                case TextHorizontalAlignment.Right:
                    x = (int)(_rect.Right - textSize.X - 1);
                    break;
            }

            switch (TextVerticalAlignment)
            {
                case TextVerticalAlignment.Top:
                    y = _rect.Top-1;
                    break;
                case TextVerticalAlignment.Center:
                    y = (int)( _rect.Bottom - _rect.Height / 2
                               - textSize.Y / 2);
                    break;
                case TextVerticalAlignment.Bottom:
                    y = (int) (_rect.Bottom - textSize.Y - 1);
                    break;
            }

            _posText = new Vector2(x, y);
        }

        public override void Draw(SpriteBatch batch)
        {
            switch (_state)
            {
                case UIButtonState.Normal:
                    DrawNormal(batch);
                    break;
                case UIButtonState.Pressed:
                    DrawPressed(batch);
                    break;
                case UIButtonState.Hover:
                    DrawHover(batch);
                    break;
            }
        }

        public void DrawNormal(SpriteBatch batch)
        {
            if (BackgroundStyle == BackgroundStyle.Stretch)
            {
                batch.Begin();
                batch.Draw(_tex, _rect, Color.White);
            } else
            if (BackgroundStyle == BackgroundStyle.Tiling)
            {
                batch.Begin(SpriteSortMode.Deferred, 
                            null, 
                            SamplerState.AnisotropicWrap);
                Vector2 v = new Vector2(_x, _y);
                batch.Draw(_tex, v,
                           _rect, Color.White);
            }
            batch.End();
            batch.Begin();
            batch.DrawString(_font,
                             _text, 
                             _posText, 
                             Color.White);
            batch.End();
        }
        public void DrawPressed(SpriteBatch batch)
        {
            if (BackgroundStyle == BackgroundStyle.Stretch)
            {
                batch.Begin();
                batch.Draw(_tex, _rect, Color.Gray);
            }
            else
            if (BackgroundStyle == BackgroundStyle.Tiling)
            {
                batch.Begin(SpriteSortMode.Deferred,
                            null,
                            SamplerState.AnisotropicWrap);
                Vector2 v = new Vector2(_x, _y);
                batch.Draw(_tex, v,
                           _rect, Color.Gray);
            }
            batch.End();
            batch.Begin();
            batch.DrawString(_font,
                             _text,
                             _posText,
                             Color.White);
            batch.End();
        }
        public void DrawHover(SpriteBatch batch)
        {
            if (BackgroundStyle == BackgroundStyle.Stretch)
            {
                batch.Begin();
                batch.Draw(_tex, _rect, Color.Red);
            }
            else
            if (BackgroundStyle == BackgroundStyle.Tiling)
            {
                batch.Begin(SpriteSortMode.Deferred,
                            null,
                            SamplerState.AnisotropicWrap);
                Vector2 v = new Vector2(_x, _y);
                batch.Draw(_tex, v,
                           _rect, Color.Red);
            }
            batch.End();
            batch.Begin();
            batch.DrawString(_font,
                             _text,
                             _posText,
                             Color.White);
            batch.End();
        }

        public override void Update(MouseState ms, 
                                    MouseState prevMs)
        {
            var pos = new Vector2(ms.Position.X, ms.Position.Y);
            if (!_rect.Contains(ms.Position))
            {
                if (IsMouseOver)
                {
                    MouseLeave?.Invoke(pos);
                    _state = UIButtonState.Normal;
                    IsMouseOver = false;
                }
                return;
            }
            if (! IsMouseOver)
            {
                MouseEnter?.Invoke(pos);
                _state = UIButtonState.Hover;
                IsMouseOver = true;
            }
            if (ms.LeftButton == ButtonState.Pressed)
            {
                MouseLeftButtonDown?.Invoke(pos);
                _state = UIButtonState.Pressed;
            }
            if (ms.LeftButton == ButtonState.Released)
            {
                MouseLeftButtonUp?.Invoke(pos);
                if (prevMs.LeftButton == ButtonState.Pressed)
                {
                    MouseLeftButtonClick?.Invoke(pos);
                }
            }
            //-----------------------
            if (ms.RightButton == ButtonState.Pressed)
            {
                MouseRightButtonDown?.Invoke(pos);
            }
            if (ms.RightButton == ButtonState.Released)
            {
                MouseRightButtonUp?.Invoke(pos);
                if (prevMs.RightButton == ButtonState.Pressed)
                {
                    MouseRightButtonClick?.Invoke(pos);
                }
            }
        }
    }
}
