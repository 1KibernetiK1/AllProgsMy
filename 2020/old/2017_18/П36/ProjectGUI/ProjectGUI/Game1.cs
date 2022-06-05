using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGUI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D _btnTex;
        SpriteFont _font;

        UIButton _btn;
        MouseState ms, prevMs;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            _btn = new UIButton(_btnTex, _font);
            _btn.Width = 200;
            _btn.Left = 200;
            _btn.Top = 200;
            _btn.TextVerticalAlignment = 
                TextVerticalAlignment.Bottom;
            _btn.TextHorizontalAlignment =
                 TextHorizontalAlignment.Right;
            _btn.BackgroundStyle = BackgroundStyle.Tiling;
            _btn.MouseLeftButtonClick += _btn_MouseLeftButtonClick;

        }

        private void _btn_MouseLeftButtonClick(Vector2 pos)
        {
            _btn.Text = "Click!";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _btnTex = Content
                .Load<Texture2D>("back");
            _font = Content
                .Load<SpriteFont>("F14");
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
            ms = Mouse.GetState();
            _btn.Update(ms, prevMs);
            prevMs = ms;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _btn.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
