using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using MG = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MgDemoPhysics
{
    public class PhysObject
    {
        static public float Unit2Pixel = 100f;
        static public float Pixel2Unit = 1 / Unit2Pixel;

        public Body Body;

        public Texture2D Tex;

        private MG.Vector2 Size;

        public MG.Vector2 Position
        {
            get {
                return
                Body.Position* Unit2Pixel;
            }
            set {
                Body.Position = value * Pixel2Unit;
            }
        }

        private MG.Vector2 _origin;

        public PhysObject(World world,
                          Texture2D tex,
                          MG.Vector2 size,
                          float mass)
        {
            // 1) создаём физич тело
            Body = BodyFactory
                .CreateRectangle(world,
                                 size.X*Pixel2Unit,
                                 size.Y*Pixel2Unit,
                                 mass);
            Body.BodyType = BodyType.Dynamic;
            Tex = tex;
            Size = size;
            _origin = new MG.Vector2(Tex.Width/2,
                                     Tex.Height/2);
        }

        public void Draw(SpriteBatch batch)
        {
            MG.Vector2 scale =
                new MG.Vector2(Size.X / (float)Tex.Width,
                               Size.Y / (float)Tex.Height);
            batch.Draw(Tex, Position, null, MG.Color.White,
                       Body.Rotation,_origin, scale, 
                       SpriteEffects.None, 1);

        }
        
    }
}
