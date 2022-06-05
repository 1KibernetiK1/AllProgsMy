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
    public class PartycleSpray : ParticleController
    {
        public SpraySettings Settings;
        private Random rnd;
        public PartycleSpray(Game game, string partycleName) : base(game, partycleName)
        {
            rnd = new Random();

        }
        private float CalcrndValue(float start, float disp)
        {
            float range = start * disp;
            float min = start - range;
            double r = rnd.NextDouble();
            float value = (float)(min + range * r);
            return value;
        }
        public void Emit()
        {
            var p = new Particle(_tex);
            //координаты частицы
            double r = rnd.NextDouble();
            
            Rectangle rect = Settings.Rect;
            int x = (int)(rect.Left + rect.Width * r);
            r = rnd.NextDouble();
            int y = (int)(rect.Top + rect.Height * r);
            p.Pos = new Vector2(x, y);
            //---------------------------
            //вектор движения частицы
            float half = Settings.Range / 2;
            float dir = (float)Math.Atan2(Settings.Direction.Y, Settings.Direction.X);
            float left = dir - half;
            r = rnd.NextDouble();
            float alpha = (float)(left + (half * 2) * r);
            //вычисляем разброс в процентах от целого
            float speed = CalcrndValue(Settings.Stretch, Settings.SpeedDisp);
            //--------------------------------------
            float vx = (float)(speed * Math.Cos(alpha));
            float vy = (float)(speed * Math.Sin(alpha));
            p.Vel = new Vector2(vx, vy);
            //--------------------------------------
            // вращение
            float rotate = CalcrndValue(Settings.Stretch, Settings.RotateDisp);
            // развер частицы 
            float size = CalcrndValue(Settings.StartSize, Settings.SizeDisp);
            p.RotationSpeed = rotate;
            p.Size = size;
            // скорость роста
            float sizeV = CalcrndValue(Settings.SizeV, Settings.SizeVDisp);
            p.GrowSpeed = sizeV;
            //---------------------
            _list.Add(p);
        }
    }
}
