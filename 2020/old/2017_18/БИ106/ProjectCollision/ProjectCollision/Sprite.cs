using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectCollision
{
    public class Sprite
    {
        public Rectangle Intersect(Rectangle r1, 
                                   Rectangle r2)
        {
            int left = Math.Max(r1.Left, r2.Left);
            int top = Math.Max(r1.Top, r2.Top);
            int bottom = Math.Min(r1.Bottom, r2.Bottom);
            int right = Math.Min(r1.Right, r2.Right);
            int w = right - left;
            int h = bottom - top;
            return new Rectangle(left, top, w, h);
        }


        // ПОПИКСЕЛЬНАЯ проверка
        // пиксель!
        // PP - PerPixel
        public bool IsPPCollision(Sprite another)
        {
            // 1) нужны точки из текстур
            int size = _tex.Width * _tex.Height;
            Color[] col1 = new Color[size];
            this._tex.GetData<Color>(col1);
            //-----------------------------
            size = another._tex.Width * another._tex.Height;
            Color[] col2 = new Color[size];
            another._tex.GetData<Color>(col2);
            //================================
            Rectangle r1 = this.Bounds;
            Rectangle r2 = another.Bounds;
            Rectangle inter = Intersect(r1, r2);
            // проверяем каждую точку
            for (int i = 0; i < inter.Height; i++)
            {
                for (int j = 0; j < inter.Width; j++)
                {

                }
            }
        }


        private Rectangle _bounds;

        // bounce
        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }


        protected Texture2D _tex;

        private Vector2 _v;

        public Vector2 V
        {
            get { return _v; }
            set { _v = value; }
        }


        private Vector2 _pos;

        public Vector2 Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                _bounds.X = (int) (_pos.X - _tex.Width / 2);
                _bounds.Y = (int) (_pos.Y - _tex.Height / 2);
            }
        }

        private float _scale;

        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        private float _angle;

        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        private Vector2 _origin;

        public Sprite(Texture2D tex)
        {
            _tex = tex;
            _origin = new Vector2(
                tex.Width/2,
                tex.Height/2);
            _scale = 1.0f;
            _bounds = new 
                Rectangle(0, 0, tex.Width, tex.Height);
        } 

        virtual public void Draw(SpriteBatch batch)
        {
            batch.Draw(_tex, // картинка
                       _pos, // положение
                       null, // прямоуг вырезания
                       Color.White, // цвет смешивания
                       _angle, // угол поворота
                       _origin, // точка поворота
                       _scale, // коэф масштабирования
                       SpriteEffects.None, // зеркалирование
                       1 // номер слоя
                       );
        }

        public void Move(Vector2 delta)
        {
            _pos += delta;
            _bounds.X = (int)(_pos.X - _tex.Width / 2);
            _bounds.Y = (int)(_pos.Y - _tex.Height / 2);
        }

        public bool IsCollision(Sprite another)
        {
            Rectangle r1 = this.Bounds;
            Rectangle r2 = another.Bounds;
            if (r1.Intersects(r2))
            {
                return true;
            }
            return false;
        }
    }
}
