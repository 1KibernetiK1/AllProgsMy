using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGProjectUserControl
{
    public class Ammo : Sprite
    {
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                if (_quantity < 0)
                    _quantity = 0;
            }
        }

        private List<Sprite> _list;

        public Ammo(Texture2D tex)
            :base(tex)
        {
            _quantity = 10;
            _list = new List<Sprite>();
            Initialize();
        }

        private void Initialize()
        {
            float x = 20, y = 40;
            for (int i = 0; i < _quantity; i++)
            {
                Sprite sp = new Sprite(_tex);
                sp.Scale = 0.3f;
                sp.Angle = (float)-Math.PI / 2;
                sp.Pos = new Vector2(x, y);
                x += 20;
                _list.Add(sp);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < _quantity; i++)
            {
                Sprite s = _list[i];
                s.Draw(batch);
            }
        }

    }
}
