using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MonoGameLight
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Random rnd;

        List<SpotLight> list;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D _texLight, _texTile;

        SpotLight spot;
        ControllerMouse ctrlMs;

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
            rnd = new Random();
            spot = new SpotLight(_texLight);
            spot.Pos = new Vector2(100,100);
            spot.Scale = 0.6f;
            spot.LightColor = Color.Goldenrod;
            //--------------------------------
            ctrlMs = new ControllerMouse(this);
            ctrlMs.Attach(spot);
            //------------------
            list = new List<SpotLight>();
            ctrlMs.Click += CtrlMs_Click;
        }

        private void CtrlMs_Click(Vector2 pos)
        {
            list.Add(spot);
            spot = new SpotLight(_texLight);
            spot.Pos = pos;
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            spot.LightColor = new Color(r,g,b);
            spot.Scale = rnd.Next(20, 100) / 100f;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _texLight = Content
                .Load<Texture2D>("light");
            _texTile = Content
                .Load<Texture2D>("tile");
        }

        private void DrawBackround()
        {
            var rct = Window.ClientBounds;
            // выполняем тайлинг - фон черепичкой 
            spriteBatch.Begin(SpriteSortMode.Deferred,
                null,
                SamplerState.AnisotropicWrap, 
                null, null, null,null);
            spriteBatch.Draw(_texTile, 
                             Vector2.Zero, 
                             rct,
                             Color.White,
                             0,
                             Vector2.Zero,
                             1f,
                             SpriteEffects.None,
                             1);
            spriteBatch.End();
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawBackround();
            foreach (var s in list)
            {
                s.Draw(spriteBatch);
            }
            spot.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
