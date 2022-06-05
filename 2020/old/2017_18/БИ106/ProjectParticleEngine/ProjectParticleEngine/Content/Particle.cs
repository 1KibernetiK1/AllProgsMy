using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectParticleEngine.Content
{
    public delegate void EventParticle(Particle p);
    public class Particle
    {
        public event EventParticle ParticleDead;

        #region Характеристики частицы
        /// <summary>
        /// Картинка
        /// </summary>
        public Texture2D Tex;

        /// <summary>
        /// Положение в пр-ве
        /// </summary>
        public Vector2 Pos;

        /// <summary>
        /// Линейная скорость движ
        /// </summary>
        public Vector2 Vel;

        /// <summary>
        /// Угол поворота частицы
        /// </summary>
        public float Angle;

        /// <summary>
        /// Скорость и направление вращения +/-
        /// </summary>
        public float RotationSpeed;

        /// <summary>
        /// Размер частицы
        /// </summary>
        public float Size;

        /// <summary>
        /// Скорость роста частиц +/-
        /// </summary>
        public float GrowSpeed;

        /// <summary>
        /// Степень прозрачность
        /// </summary>
        public float Transparency;

        /// <summary>
        /// Скорость изменения прозрачности
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

        // коор-ты центра текстуры
        private Vector2 _origin;
        // счётчик жизни частицы
        private int _lifeCounter;
        #endregion

        public Particle(Texture2D tex)
        {
            Tex = tex;
            _origin = new Vector2(tex.Width/2, tex.Height/2);
            Pos = new Vector2(0,0);
            Vel = new Vector2(0,0);
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
            // 1) перемещение
            Pos += Vel;
            // 2) вращение
            Angle += RotationSpeed;
            // 3) изм размера
            Size += GrowSpeed;
            // 4) изм прозрачность
            Transparency += TranSpeed;
            Color.A = (byte)(255 * Transparency);
            // 5) время жизни
            _lifeCounter++;
            // Проверить - частица каюк?
            if (_lifeCounter > LifeTime ||
                Size <= 0 ||
                Transparency >=1)
            {
                // Нужно будет отключить
                ParticleDead(this);
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
