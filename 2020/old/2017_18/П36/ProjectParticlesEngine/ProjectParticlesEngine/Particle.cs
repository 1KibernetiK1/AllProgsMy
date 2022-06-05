using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectParticlesEngine
{
    public class Particle
    {
        #region Характеристики частицы
        private Vector2 _pos;
        /// <summary>
        /// Положение в пространстве
        /// </summary>
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        private Texture2D _tex;
        public Texture2D Tex
        {
            get { return _tex; }
            set { _tex = value; }
        }

        private Vector2 _vel;
        /// <summary>
        /// Линейная скорость частиц
        /// </summary>
        public Vector2 Vel
        {
            get { return _vel; }
            set { _vel = value; }
        }

        private float _angle;
        /// <summary>
        /// угол поворота частицы
        /// </summary>
        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        private float _angularV;
        /// <summary>
        /// Угловая скорость 
        /// (скорость вращения)
        /// </summary>
        public float AnagularV
        {
            get { return _angularV; }
            set { _angularV = value; }
        }

        private float _scale;
        /// <summary>
        /// Коэф-т масштабировать
        /// </summary>
        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        private float _scaleV;
        /// <summary>
        /// скорость изменения размера
        /// </summary>
        public float ScaleV
        {
            get { return _scaleV; }
            set { _scaleV = value; }
        }

        private float _alpha;
        /// <summary>
        /// Уровень прозрачность частиц
        /// </summary>
        public float Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }

        private float _alphaV;
        /// <summary>
        /// скорость изменения прозрачности
        /// </summary>
        public float AlphaV
        {
            get { return _alphaV; }
            set { _alphaV = value; }
        }

        private Color _pColor;
        /// <summary>
        /// Цвет частицы
        /// </summary>
        public Color PColor
        {
            get { return _pColor; }
            set { _pColor = value; }
        }

        private int _lifeTime;
        /// <summary>
        /// Время жизни
        /// </summary>
        public int LifeTime
        {
            get { return _lifeTime; }
            set { _lifeTime = value; }
        }


        private int _lifeCounter;
        private Vector2 _center;
        #endregion

        public Particle(Texture2D tex)
        {
            // начальные параметры
            _tex = tex;
            _center = new Vector2(tex.Width/2,tex.Height/2);
            _pos = Vector2.Zero;
            _vel = Vector2.Zero;
            _angle = 0f;
            _angularV = 0f;
            _scale = 1f;
            _scaleV = 0f;
            _alpha = 1f;
            _alphaV = 0f;
            _pColor = Color.White;
            _lifeTime = 300;
            _lifeCounter = 0;
        }

        public bool Update()
        { // изменения частицы со временем
            // 1) линейное движение
            _pos += _vel;
            // 2) вращение
            _angle += _angularV;
            // 3) изменение размера
            _scale += _scaleV;
            // 4) изменение прозрачности
            _alpha += _alphaV;
            _pColor.A = (byte)(_alpha * 255);
            // 5) меняем время жизни
            _lifeCounter++;
            // 6) проверка на жизнеспособность
            bool IsAlive = true;
            if (_lifeCounter >= _lifeTime ||
                _scale <= 0 ||
                _alpha <= 0)
            {
                IsAlive = false;
            }
            return IsAlive;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(
                _tex,
                _pos,
                null,
                _pColor,
                _angle, 
                _center,
                _scale,
                SpriteEffects.None, 
                1f);
        }
    }
}
