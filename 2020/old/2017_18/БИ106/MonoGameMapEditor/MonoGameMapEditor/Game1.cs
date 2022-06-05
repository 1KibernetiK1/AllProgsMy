using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameMapEditor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MapLevel map;
        MapEditor editor;

        KeyboardState ks, prevKs;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            map = new MapLevel(this);
            map.SetSize(1500, 1500);
            editor = new MapEditor(this, map);
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

            // TODO: use this.Content to load your game content here
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
            ks = Keyboard.GetState();
            if (ks.IsKeyUp(Keys.X) &&
                prevKs.IsKeyDown(Keys.X))
            {
                map.Scale(+0.1f);
            } 
            if (ks.IsKeyUp(Keys.Z) &&
                prevKs.IsKeyDown(Keys.Z))
            {
                map.Scale(-0.1f);
            }

            if (ks.IsKeyUp(Keys.Left) &&
                prevKs.IsKeyDown(Keys.Left))
            {
                map.Scroll(-1, 0);
            }
            if (ks.IsKeyUp(Keys.Right) &&
                prevKs.IsKeyDown(Keys.Right))
            {
                map.Scroll(+1, 0);
            }
            if (ks.IsKeyUp(Keys.Up) &&
                prevKs.IsKeyDown(Keys.Up))
            {
                map.Scroll(0, -1);
            }
            if (ks.IsKeyUp(Keys.Down) &&
                prevKs.IsKeyDown(Keys.Down))
            {
                map.Scroll(0, +1);
            }
            prevKs = ks;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
