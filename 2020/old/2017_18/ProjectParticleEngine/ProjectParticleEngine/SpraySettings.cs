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
    /// <summary>
    /// Настройка разбрызгивания
    /// </summary>
    public  class SpraySettings
    {
        /// <summary>
        /// положение в пр-ве
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// область зарождения
        /// </summary>
        public Rectangle Rect;
        /// <summary>
        /// главное направление выброса частиц
        /// </summary>
        public Vector2 Direction;
        /// <summary>
        /// Главный угол разброса частиц
        /// </summary>
        public float Range;
        /// <summary>
        /// Сила или скорость максимальная выброса частиц
        /// </summary>
        public float Stretch;
        //----------------------
        public float StartSize;
        public float SizeDisp;
        public float SizeV;
        public float SizeVDisp;
        //----------------------
        public float RotateSpeed;
        public float RotateDisp;
        //----------------------
        public float SpeedDisp;

    }
}
