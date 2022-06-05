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
    public class Label : UIControl
    {
        public Color ForeColor;
        public Color BackColor;

       

        public Label(string text)
        {
            _text = text;
            FontSize = FontSize.Medium;
            ForeColor = Color.White;
            BackColor = Color.Black;
            CalculateBounds();
        }

        public override void Draw(SpriteBatch batch)
        {
            UISystem.FillRectangle(_bounds, BackColor);
            batch.DrawString(_font, _text, _pos, ForeColor);
        }
    }
}
