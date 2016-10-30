using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject
{
    public class MainSolid
    {
        BasicEffect effect;
        GraphicsDeviceManager graphics;
        Camera camera;
        VertexPosition[] stationVerts;

        public MainSolid(BasicEffect _effect, Camera _camera, GraphicsDeviceManager _graphics)
        {
            stationVerts = InitializeStation();

            effect = _effect;
            camera = _camera;
            graphics = _graphics;
        }

        public VertexPosition[] InitializeStation()
        {
            VertexPosition[] sVerts = new VertexPosition[12];
            sVerts[0].Position = new Vector3(-20, -20, 0);
            sVerts[1].Position = new Vector3(-20, 20, 0);
            sVerts[2].Position = new Vector3(20, -20, 0);

            sVerts[3].Position = sVerts[1].Position;
            sVerts[4].Position = new Vector3(20, 20, 0);
            sVerts[5].Position = sVerts[2].Position;

            sVerts[6].Position = sVerts[1].Position;
            sVerts[7].Position = new Vector3(-20, 20, 20);
            sVerts[8].Position = sVerts[4].Position;

            sVerts[9].Position = sVerts[7].Position;
            sVerts[10].Position = new Vector3(20, 20, 20);
            sVerts[11].Position = sVerts[8].Position;

            return sVerts;
        }

        public void DrawStation()
        {
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ProjectionMatrix;

            effect.TextureEnabled = false;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, stationVerts, 0, 4); // The number of triangles to draw
            }
        }
    }
}
