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
    public class ParticleSpray :
        ParticleController
    {
        


        public ParticleSpray(Game game, string particleName) :
            base(game, particleName)
        {
        }
    }
}
