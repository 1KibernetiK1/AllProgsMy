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
    /// <summary>
    /// Настройки разбрызгивателя
    /// </summary>
    public class SpraySettings
    {
        /// <summary>
        /// Положение в пр-ве
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// Область зарождения частиц
        /// </summary>
        public Rectangle Rect;
        /// <summary>
        /// Главное направление
        /// выброса частиц
        /// </summary>
        public Vector2 Direction;
        /// <summary>
        /// Главный Угол разброса частиц
        /// </summary>
        public float Dispersion;
        /// <summary>
        /// Максима Сила/скорость выброса частиц
        /// </summary>
        public float Stretch;
        //-------------------
        public float StartSize;
        public float SizeDisp;

    }
}
