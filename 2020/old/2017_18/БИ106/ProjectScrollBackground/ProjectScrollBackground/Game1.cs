using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectScrollBackground
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D _tex1, _tex2;
        Rectangle _rect;
        // скорость и направление прокрутки
        float _sx, _sy;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _tex1 = Content
                .Load<Texture2D>("background");
            _tex2 = Content
                .Load<Texture2D>("layer1");
            _rect = new Rectangle(0, 0,
                    _tex1.Width, _tex1.Height);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _sx -= 1.7f;
            _sy += 2.8f;
            _rect.X = (int) _sx;
            _rect.Y = (int) _sy;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // вторую текстуру - тайлинг (тиражируем)
            spriteBatch.Begin(SpriteSortMode.Deferred,
                              null, SamplerState.PointWrap,
                              null, null);
            spriteBatch.Draw(_tex1, Vector2.Zero, Color.White);
            spriteBatch.Draw(_tex2, Vector2.Zero, _rect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
