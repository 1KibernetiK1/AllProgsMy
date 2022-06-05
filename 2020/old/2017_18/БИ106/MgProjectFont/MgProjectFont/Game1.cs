using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MgProjectFont
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        UISystem hud;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;

        int _frameCounter = 0;
        int msec = 0;
        int fps = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            hud = new UISystem(this);
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
            // TODO: Add your initialization logic here
            var label = new Label("Как дела");
            label.Location = new Vector2(200, 200);
            label.BackColor = Color.Red;
            //--------------------------
            var btn = new Button("Отмена");
            btn.Location = new Vector2(100, 50);
            btn.BackColor = Color.Green;
            btn.Width = 100;
            btn.Height = 35;
            btn.Click += Btn_Click;

            var btn2 = new Button("Привет");
            btn2.Location = new Vector2(100, 100);
            btn2.BackColor = Color.Green;
            btn2.Width = 100;
            btn2.Height = 35;
            //-----------------------------------------
            hud.Add(label);
            hud.Add(btn);
            hud.Add(btn2);
        }

        private void Btn_Click(UIControl ctrl, Vector2 pos)
        {
            ctrl.Text = "Пока";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Font20");
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
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            msec += gameTime.ElapsedGameTime.Milliseconds;
            _frameCounter++;
            if (msec > 1000)
            {
                fps = _frameCounter;
                _frameCounter = 0;
                msec = 0;
                
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, 
                                   "Привет, fps="+
                                   fps.ToString(), 
                                   new Vector2(10,10), 
                                   Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
