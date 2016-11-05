using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        MainSolid stacja;
        Platform peron;
        BasicEffect effect;
        Texture2D podlogaTexture, scianyTexture, betonTexture;

        Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// </summary>
        protected override void Initialize()
        {
            effect = new BasicEffect(graphics.GraphicsDevice);

            camera = new Camera(graphics.GraphicsDevice);

            stacja = new MainSolid(effect, camera, graphics, 40, 100);
            peron = new Platform(effect, camera, graphics, 40, 100);

            base.Initialize();
        }
       
        /// <summary>
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            scianyTexture = this.Content.Load<Texture2D>("scianaTekstura");
            podlogaTexture = this.Content.Load<Texture2D>("podłogaTekstura");
            betonTexture = this.Content.Load<Texture2D>("beton");
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            stacja.DrawStation(betonTexture, scianyTexture);
            peron.DrawPlatform(podlogaTexture, scianyTexture);

            base.Draw(gameTime);
        }
    }
}
