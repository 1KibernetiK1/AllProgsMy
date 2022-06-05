using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectParticleEngine
{
    public delegate void EventPatricle(Particle p);
    public class Particle
    {
        public event EventPatricle PartycleDead;

        #region Характаристики частицы
        /// <summary>
        /// Картинка
        /// </summary>
        public Texture2D Tex;
        /// <summary>
        /// Положение в пр-ве
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// Линейная скорость движения
        /// </summary>
        public Vector2 Vel;
        /// <summary>
        /// Угол поворота частицы 
        /// </summary>
        public float Angle;
        /// <summary>
        /// Скорость и направление вращения
        /// </summary>
        public float RotationSpeed;
        /// <summary>
        /// Размер частицы
        /// </summary>
        public float Size;
        /// <summary>
        /// Скорость роста частиц
        /// </summary>
        public float GrowSpeed;
        /// <summary>
        /// Cтепень прозрачности
        /// </summary>
        public float Transparency;
        /// <summary>
        /// Cкорость изменения прозрачности 
        /// </summary>
        public float TranSpeed;
        /// <summary>
        /// Цвет частиц
        /// </summary>
        public Color Color;
        /// <summary>
        /// Время жизни
        /// </summary>
        public int LifeTime;
        //координаты центры текстуры
        private Vector2 _origin;
        // счетчик жизни частицы
        private int _lifeCounter;
        #endregion

        public Particle(Texture2D tex)
        {
            Tex = tex;
            _origin = new Vector2(tex.Width / 2, tex.Height / 2);
            Pos = new Vector2(0, 0);
            Vel = new Vector2(0, 0);
            Angle = 0;
            RotationSpeed = 0;
            Size = 1;
            GrowSpeed = 0;
            Transparency = 0;
            TranSpeed = 0;
            Color = Color.White;
            LifeTime = 300;
            _lifeCounter = 0;
        }
        public void Update()
        {
            //1) перемещение
            Pos += Vel;
            //2) вращение
            Angle += RotationSpeed;
            //3) изм размера
            Size += GrowSpeed;
            //4) изм прозрачности
            Transparency += TranSpeed;
            Color.A = (byte)(255 * Transparency);
            //5) время жизни
            _lifeCounter++;
            // Проверить - частица каюк?
            if(_lifeCounter > LifeTime || Size <= 0 || Transparency >= 1)
            {
                // нужно будет отключить частицу
                if(PartycleDead != null)
                PartycleDead(this);
            }
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(
                Tex,
                Pos,
                null,
                Color,
                Angle,
                _origin,
                Size,
                SpriteEffects.None,
                1);
        }
    }

}
