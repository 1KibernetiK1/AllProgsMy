using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MGProjectUserControl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite ship, cursor;
        Ammo ammo;
        ControllerGun gun;
        ControllerKeyboard kbrd;
        ControllerMouse msCtrl;
        ControllerMouseFollower msFolow;
        Texture2D tex1, tex2, tex3;

        static public List<DisplayMode> GetResolution()
        {
            List<DisplayMode> modes
                = new List<DisplayMode>();
            
            //----------------------------
            DisplayModeCollection col =
                GraphicsAdapter
                    .DefaultAdapter
                    .SupportedDisplayModes;
            //-----------------------------
            foreach (var d in col)
            {
                modes.Add(d);
            }
            return modes;
        }

        public Game1(StartOptions opt)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = opt.IsFullscreen;
            graphics.PreferredBackBufferWidth =
                opt.Mode.Width;
            graphics.PreferredBackBufferHeight =
                opt.Mode.Height;
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
            ship = new Sprite(tex1);
            ship.Pos = new Vector2(200, 200);
            ship.Scale = 0.5f;
            //----------------
            ammo = new Ammo(tex3);
            //----------------
            cursor = new Sprite(tex2);
            cursor.Scale = 0.3f;
            //----------------
            kbrd = new ControllerKeyboard(this);
            kbrd.Speed = 3.0f;
            kbrd.Attach(ship);
            //----------------
            msCtrl = new ControllerMouse(this);
            msCtrl.Attach(cursor);
            //----------------
            msFolow = new ControllerMouseFollower(this);
            msFolow.Attach(ship);
            //-------------------
            gun = new ControllerGun(this);
            gun.Attach(ship);
            msCtrl.Click += MsCtrl_Click;
        }

        private void MsCtrl_Click(Vector2 pos)
        {
            if (ammo.Quantity >0)
                gun.Fire(pos);
            ammo.Quantity--;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tex1 = Content.Load<Texture2D>("spaceship");
            tex2 = Content.Load<Texture2D>("cursor");
            tex3 = Content.Load<Texture2D>("bullet");
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
            // kbrd.Update();
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
            ship.Draw(spriteBatch);
            ammo.Draw(spriteBatch);
            cursor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
