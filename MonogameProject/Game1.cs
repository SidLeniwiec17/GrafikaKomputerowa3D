using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        //Bench lawka;
        Camera camera;
        LightSource light;
        public List<LightSource> Lights { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            effect = new BasicEffect(graphics.GraphicsDevice);

            //lawka = new Bench();
            //lawka.Initialize(Content);

            camera = new Camera(graphics.GraphicsDevice);

            stacja = new MainSolid(effect, camera, graphics, 40, 100);

            peron = new Platform(effect, camera, graphics, 40, 100);

            Lights = new List<LightSource>();
            CreateLights();

            base.Initialize();
        }

        private void CreateLights()
        {
            light= new PointLight()
            {
                Possition = new Vector3(0, 0, 8),
                Attenuation = 5000,
                Falloff = 2
            };
            Lights.Add(light);
        }

        protected override void LoadContent()
        {
            scianyTexture = this.Content.Load<Texture2D>("scianaTekstura");
            podlogaTexture = this.Content.Load<Texture2D>("podłogaTekstura");
            betonTexture = this.Content.Load<Texture2D>("beton");
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            stacja.DrawStation(betonTexture, scianyTexture);
            peron.DrawPlatform(podlogaTexture, scianyTexture);

            float aspectRatio = graphics.GraphicsDevice.Viewport.Width / (float)graphics.GraphicsDevice.Viewport.Height;

            //lawka.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
