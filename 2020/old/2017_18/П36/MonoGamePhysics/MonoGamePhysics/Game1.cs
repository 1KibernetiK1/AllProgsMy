using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using System.Collections.Generic;

namespace MonoGamePhysics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        World world;
        Texture2D texFloor, texBox;
        PhysicsBody floor, 
                    leftWall, 
                    rightWall;
        List<PhysicsBody> listCubes;
        MouseState prevState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 1024;
        }

        private void SpawnBox(int x, int y)
        {
            Vector2 size = new Vector2(50, 50);
            PhysicsBody box = new PhysicsBody(world, size);
            box.Tex = texBox;
            box.body.BodyType = BodyType.Dynamic;
            box.Pos = new Vector2(x,y);
            listCubes.Add(box);
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
            world = new World(new Vector2(0, 9.8f));
            listCubes = new List<PhysicsBody>();
            base.Initialize();

            // Создадим физический пол
            int w = this.Window.ClientBounds.Width;
            int h = this.Window.ClientBounds.Height;
            Vector2 size = new Vector2(w, 50);

            floor = new PhysicsBody(world, size);
            floor.Tex = texFloor;
            floor.Pos = new Vector2(w/2, h-50);
            floor.body.BodyType = BodyType.Static;
            // Создадим стену слева и справа
            size = new Vector2(50,h);
            leftWall = new PhysicsBody(world, size);
            leftWall.Tex = texFloor;
            leftWall.Pos = new Vector2(10, h/2);
            leftWall.body.BodyType = BodyType.Static;
            //--------------------------
            rightWall = new PhysicsBody(world, size);
            rightWall.Tex = texFloor;
            rightWall.Pos = new Vector2(w-50, h / 2);
            rightWall.body.BodyType = BodyType.Static;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texFloor = Content.Load<Texture2D>("Floor");
            texBox = Content.Load<Texture2D>("Box");
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

            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed
                && 
                prevState.LeftButton == ButtonState.Released)
            {
                SpawnBox(ms.X, ms.Y);
            }

            float time = (float)
            gameTime.ElapsedGameTime.TotalSeconds;
            // обновление всей физике в "мире"
            world.Step(time);

            prevState = ms;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            floor.Draw(spriteBatch);
            leftWall.Draw(spriteBatch);
            rightWall.Draw(spriteBatch);
            foreach (var c in listCubes)
            {
                c.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
