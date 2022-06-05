using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace MonoGamePhysics
{
    class PhysicsBody
    {
        public static float unit2Pixel = 100f;
        public static float pixel2unit = 1 / 100f;
        public Body body;
        public Texture2D Tex;
        public Vector2 Size;

        public Vector2 Pos
        {
            get { return body.Position * unit2Pixel; }
            set { body.Position = value * pixel2unit; }
        }

        public PhysicsBody(World world, Vector2 size)
        {
            body = BodyFactory.
                CreateRectangle(world, size.X * pixel2unit, 
                                       size.Y * pixel2unit, 1);
            Size = size;
        }

        public void Draw(SpriteBatch batch)
        {
            Vector2 origin = new Vector2(Tex.Width/2,
                                         Tex.Height/2);
            Vector2 scale = 
                new Vector2(Size.X / (float)Tex.Width,
                            Size.Y / (float)Tex.Height);

            batch.Draw(Tex, Pos, null, Color.White,
                       body.Rotation,
                       origin, scale, SpriteEffects.None,0);
        }
    }
}
