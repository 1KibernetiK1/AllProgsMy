using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGProjectUserControl
{
    public class ControllerGun 
        : DrawableGameComponent
    {
        private Texture2D _tex;
        private List<Sprite> _bullets;
        private SpriteBatch _batch;
        private Sprite _subject;

        private float _power;

        public float Power
        {
            get { return _power; }
            set { _power = value; }
        }


        public ControllerGun(Game game)
            :base(game)
        {
            _bullets = new List<Sprite>();
            game.Components.Add(this);
            _batch = new SpriteBatch(Game.GraphicsDevice);
            LoadContent();
            _power = 8.0f;
        }

        public void Attach(Sprite sprite)
        {
            _subject = sprite;
        }

        public void Fire(Vector2 target)
        {
            // ищем вектор движения для пуль
            Vector2 start = _subject.Pos;
            Vector2 move = target - start;
            double alpha = Math.Atan2(move.Y, move.X);
            //----------------------------
            Sprite bullet = new Sprite(_tex);
            bullet.Scale = 0.1f;
            bullet.Angle = (float) alpha;
            float vx = (float) (_power * Math.Cos(alpha));
            float vy = (float) (_power * Math.Sin(alpha));
            bullet.V = new Vector2(vx, vy);
            bullet.Pos = _subject.Pos;
            //------------------------
            _bullets.Add(bullet);
        }

        public override void Initialize()
        {
            base.Initialize();
            LoadContent();
        }

        protected override void LoadContent()
        {
            _tex = Game.Content.Load<Texture2D>("bullet");
            base.LoadContent();
            
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Rectangle rect = Game.Window.ClientBounds;
            for (int i = 0; i < _bullets.Count; i++)
            {
                Sprite b = _bullets[i];
                b.Pos += b.V;
                if (! rect.Contains(b.Pos) )
                {
                    _bullets.RemoveAt(i);
                }
                // пульки удалять!!!
                // три варианта: 
                // 1) время жизни
                // 2) дистанция полёта
                // 3) границы карты
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _batch.Begin();
            foreach (var b in _bullets)
            {
                b.Draw(_batch);
            }
            _batch.End();
        }
    }
}
