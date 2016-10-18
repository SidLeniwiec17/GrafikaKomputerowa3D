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

        VertexPosition[] stationVerts;

        BasicEffect effect;

        Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// </summary>
        protected override void Initialize()
        {
            stationVerts = InitializeStation();

            effect = new BasicEffect(graphics.GraphicsDevice);

            camera = new Camera(graphics.GraphicsDevice);

            base.Initialize();
        }

        public VertexPosition[] InitializeStation()
        {
            VertexPosition[] sVerts = new VertexPosition[6];
            sVerts[0].Position = new Vector3(-20, -20, 0);
            sVerts[1].Position = new Vector3(-20, 20, 0);
            sVerts[2].Position = new Vector3(20, -20, 0);
            sVerts[3].Position = sVerts[1].Position;
            sVerts[4].Position = new Vector3(20, 20, 0);
            sVerts[5].Position = sVerts[2].Position;

            return sVerts;
        }
       
        /// <summary>
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawStation();

            base.Draw(gameTime);
        }

        void DrawStation()
        {
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ProjectionMatrix;

            effect.TextureEnabled = false;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, stationVerts, 0, 2); // The number of triangles to draw
            }
        }
    }
}
