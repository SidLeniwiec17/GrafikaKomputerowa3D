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
        Texture2D podlogaTexture, scianyTexture, betonTexture, tunelTexture;

        List<Bench> lawki;
        List<Garbage> smietniki;
        Model laweczka, smietniczek;

        Camera camera;

        int sceneSizeX = 40;
        int sceneSizeY = 100;

        //Effect diffuseEffect, textureEffect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            effect = new BasicEffect(graphics.GraphicsDevice);

            effect.LightingEnabled = true; // turn on the lighting subsystem.
            effect.DirectionalLight0.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
            effect.DirectionalLight0.Direction = new Vector3(0, 0, -1);
            effect.DirectionalLight0.SpecularColor = new Vector3(0, 0, 0);
            effect.AmbientLightColor = new Vector3(0.6f, 0.6f, 0.6f);
            effect.EmissiveColor = new Vector3(0, 0, 0);
            effect.PreferPerPixelLighting = true;


            lawki = new List<Bench>();
            for (int i = 0; i < 4; i++)
            {
                Bench lawka = new Bench();
                lawka.Initialize(Content, -18, -40 + (i * 20));
                lawki.Add(lawka);
            }

            smietniki = new List<Garbage>();
            for (int i = 0; i < 3; i++)
            {
                Garbage kosz = new Garbage();
                kosz.Initialize(Content, -15 + (i % 2 * 10), 10 + (i * 10));
                smietniki.Add(kosz);
            }

            camera = new Camera(graphics.GraphicsDevice, sceneSizeX, sceneSizeY);

            stacja = new MainSolid(effect, camera, graphics, sceneSizeX, sceneSizeY);

            peron = new Platform(effect, camera, graphics, sceneSizeX, sceneSizeY);


            base.Initialize();
        }


        protected override void LoadContent()
        {
            scianyTexture = this.Content.Load<Texture2D>("scianaTekstura");
            podlogaTexture = this.Content.Load<Texture2D>("podłogaTekstura");
            betonTexture = this.Content.Load<Texture2D>("beton");
            tunelTexture = this.Content.Load<Texture2D>("blackTxt");
            laweczka = this.Content.Load<Model>("benches");
            smietniczek = this.Content.Load<Model>("Garbage_Container_");
            //diffuseEffect = this.Content.Load<Effect>("Diffuse");
            //textureEffect = this.Content.Load<Effect>("TextureShader");
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

            stacja.DrawStation(betonTexture, scianyTexture, tunelTexture);
            peron.DrawPlatform(podlogaTexture, scianyTexture);

            float aspectRatio = graphics.GraphicsDevice.Viewport.Width / (float)graphics.GraphicsDevice.Viewport.Height;

            for (int i = 0; i < lawki.Count; i++ )
                lawki[i].Draw(camera, aspectRatio, laweczka);
            for (int i = 0; i < smietniki.Count; i++)
                smietniki[i].Draw(camera, aspectRatio, smietniczek);

            base.Draw(gameTime);
        }
    }
}
