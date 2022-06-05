using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGProjectUserControl
{
    public class Sprite
    {
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
            set { _pos = value; }
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
        }
    }
}
