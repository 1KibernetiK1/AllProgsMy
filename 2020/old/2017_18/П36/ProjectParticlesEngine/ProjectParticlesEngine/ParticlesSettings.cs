using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectParticlesEngine
{
    public class ParticlesSettings
    {
        /// <summary>
        /// Стартовый размер частицы
        /// </summary>
        public float StartSize;

        /// <summary>
        /// Разброс по размеру
        /// </summary>
        public float SizeDispersion;

        /// <summary>
        /// Скорость изменения размера
        /// </summary>
        public float SizeV;

        /// <summary>
        /// Скорость вращения
        /// </summary>
        public float Rotation;

        /// <summary>
        /// Разброс по скорости вращения
        /// </summary>
        public float RotationDispersion;

        /// <summary>
        /// Начальная степень прозрачности
        /// </summary>
        public float StartAlpha;

        /// <summary>
        /// Разброс по степени прозрачности
        /// </summary>
        public float AlphaDispersion;

        /// <summary>
        /// Скорость изменения прозрачности
        /// </summary>
        public float AlphaV;

        /// <summary>
        /// Время жизни
        /// </summary>
        public int LifeTime;

        /// <summary>
        /// Разброс по времени жизни
        /// </summary>
        public int LifeDispersion;
    }
}
