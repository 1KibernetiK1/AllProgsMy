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
    public class ParticleController:
        DrawableGameComponent
    {
        protected List<Particle> _list;
        protected Texture2D _tex;
        protected string _texName;
        protected SpriteBatch _batch;

        public ParticleController(Game game, 
                                  string particleName) 
            : base(game)
        {
            _texName = particleName;
            _list = new List<Particle>();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _tex = Game.Content.Load<Texture2D>(_texName);
            _batch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (var p in _list)
            {
                p.Update();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _batch.Begin();
            foreach (var p in _list)
            {
                p.Draw(_batch);
            }
            _batch.End();
        }
    }
}
