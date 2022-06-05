using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameShaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tex;
        Effect eff;
        // переменная для передачи в шейдер
        float lightPower = 1f;
        float phase = 0.1f;

        Rectangle _rSource;
        Rectangle _rDest;

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
            _rSource = new Rectangle(0, 0,
                tex.Width,
                tex.Height);
            _rDest = new Rectangle(0, 0,
                graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tex = Content.Load<Texture2D>("back");
            eff = Content.Load<Effect>("Shader");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Up))
            {
                lightPower += 0.005f;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                lightPower -= 0.005f;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // выбираем шейдер ОСВЕТЛЕНИЕ
            eff.CurrentTechnique = eff.Techniques["Lighter"];
            // передача переменной в шейдер
            eff.Parameters["LightPower"].SetValue(lightPower);

            spriteBatch.Begin(SpriteSortMode.Deferred,
                              null,null,null,null,
                              eff);
            // spriteBatch.Begin();
            spriteBatch.Draw(tex, _rDest, _rSource, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
