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
    public delegate void MouseEvent(UIControl ctrl, Vector2 pos);

    public enum FontSize
    {
        Small, Medium, Large
    }

    public class UISystem : DrawableGameComponent
    {
        protected UIControl prevActive = null;

        public static Dictionary<FontSize, SpriteFont> Fonts;
        private static SpriteBatch _batch;
        private static Texture2D _pixel;

        private List<UIControl> controls;
        
        public void Add(UIControl control)
        {
            controls.Add(control);
        }

        private void CreatePixel()
        {
            Color[] data = new Color[1];
            data[0] = Color.White;
            _pixel = new Texture2D(Game.GraphicsDevice,1,1);
            _pixel.SetData<Color>(data);
        }

        public static void FillRectangle(Rectangle rect, Color color)
        {
            _batch.Draw(_pixel, rect, color);
        }

        public UISystem(Game game) : base(game)
        {
            controls = new List<UIControl>();
            Fonts = new Dictionary<FontSize, SpriteFont>();
            game.Components.Add(this);
        }

        protected override void LoadContent()
        {
            CreatePixel();
            _batch = new SpriteBatch(Game.GraphicsDevice);
            var f1 = Game.Content.Load<SpriteFont>("Font10");
            var f2 = Game.Content.Load<SpriteFont>("Font14");
            var f3 = Game.Content.Load<SpriteFont>("Font20");
            Fonts.Add(FontSize.Small,  f1);
            Fonts.Add(FontSize.Medium, f2);
            Fonts.Add(FontSize.Large,  f3);
        }

        public override void Draw(GameTime gameTime)
        {
            _batch.Begin();
            foreach (var item in controls)
            {
                item.Draw(_batch);
            }
            _batch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var ks = Keyboard.GetState();
            var ms = Mouse.GetState();
            UIControl uOnMouse = null;
            Vector2 msPos = new Vector2(ms.X, ms.Y);
            foreach (var u in controls)
            {
                if ( u.GetBounds().Contains(ms.X, ms.Y))
                {
                    u.OnMouseEnter(u, msPos);
                    uOnMouse = u;
                    break;
                }
            }
            if (uOnMouse == null)
            {
                if (prevActive != null)
                    prevActive.OnMouseLeave(prevActive, msPos);
            } else
            {
                prevActive = uOnMouse;
            }
            if (ms.LeftButton == ButtonState.Pressed)
            {
                if (uOnMouse != null)
                {
                    uOnMouse.OnClick(uOnMouse, msPos);
                }
            }
        }
    }
}
