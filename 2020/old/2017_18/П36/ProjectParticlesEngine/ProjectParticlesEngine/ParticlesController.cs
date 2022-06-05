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
    public class ParticlesController
        : DrawableGameComponent
    {
        private List<Particle> _list;
        private SpriteBatch _batch;
        private Texture2D _tex;
        private string _assetName;

        public ParticlesController(Game game, 
                                   string assetName)
            :base(game)
        {
            _assetName = assetName;
            _list = new List<Particle>();
            game.Components.Add(this);
        }

        protected override void LoadContent()
        {
            _tex = Game.Content.Load<Texture2D>(_assetName);
            _batch = new SpriteBatch(Game.GraphicsDevice);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                bool IsAlive = _list[i].Update();
                if (! IsAlive)
                {
                    _list.RemoveAt(i);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _batch.Begin();
            foreach (var p in _list)
            {
                p.Draw(_batch);
            }
            _batch.End();
            base.Draw(gameTime);
        }
    }
}
