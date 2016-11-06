using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject
{
    class Platform
    {
        BasicEffect effect;
        GraphicsDeviceManager graphics;
        Camera camera;
        VertexPositionNormalTexture[] platformVerts;
        int szerX;
        int dluY;
        int wysokosc = 8;

        public Platform(BasicEffect _effect, Camera _camera, GraphicsDeviceManager _graphics, int _szer, int _dlug)
        {
            effect = _effect;
            camera = _camera;
            graphics = _graphics;
            szerX = _szer;
            dluY = _dlug;
            platformVerts = InitializePlatform();
        }

        public VertexPositionNormalTexture[] InitializePlatform()
        {
            VertexPositionNormalTexture[] sVerts = new VertexPositionNormalTexture[12];
            //podloga
            sVerts[0].Position = new Vector3(-(szerX / 2), -(dluY / 2), -(wysokosc - 3));
            sVerts[1].Position = new Vector3(-(szerX / 2), (dluY / 2), -(wysokosc - 3));
            sVerts[2].Position = new Vector3((szerX / 4), -(dluY / 2), -(wysokosc - 3));

            sVerts[3].Position = sVerts[1].Position;
            sVerts[4].Position = new Vector3((szerX / 4), (dluY / 2), -(wysokosc - 3));
            sVerts[5].Position = sVerts[2].Position;

            //prawasciana
            sVerts[6].Position = new Vector3((szerX / 4), -(dluY / 2), - wysokosc);
            sVerts[7].Position = sVerts[2].Position;
            sVerts[8].Position = new Vector3((szerX / 4), (dluY / 2), - wysokosc);

            sVerts[9].Position = sVerts[2].Position;
            sVerts[10].Position = sVerts[4].Position;
            sVerts[11].Position = new Vector3((szerX / 4), (dluY / 2), -wysokosc);


            sVerts = AddNormalsTextures(sVerts);

            return sVerts;
        }

        public VertexPositionNormalTexture[] AddNormalsTextures(VertexPositionNormalTexture[] sVerts)
        {

            for (int i = 0; i < sVerts.Length / 3; i++)
            {
                Vector3 firstvec = sVerts[i * 3 + 1].Position - sVerts[i * 3].Position;
                Vector3 secondvec = sVerts[i * 3].Position - sVerts[i * 3 + 2].Position;
                Vector3 normal = Vector3.Cross(firstvec, secondvec);
                normal.Normalize();
                sVerts[i * 3].Normal = normal;
                sVerts[i * 3 + 1].Normal = normal;
                sVerts[i * 3 + 2].Normal = normal;

                sVerts[i * 3].Normal = normal;
                sVerts[i * 3 + 1].Normal = normal;
                sVerts[i * 3 + 2].Normal = normal;
            }

            int repetitions = szerX / 2;
            for (int i = 0; i < sVerts.Length; i = i + 6)
            {
                sVerts[i].TextureCoordinate = new Vector2(0, 0);
                sVerts[i + 1].TextureCoordinate = new Vector2(0, repetitions);
                sVerts[i + 2].TextureCoordinate = new Vector2(repetitions, 0);

                sVerts[i + 3].TextureCoordinate = sVerts[1].TextureCoordinate;
                sVerts[i + 4].TextureCoordinate = new Vector2(repetitions, repetitions);
                sVerts[i + 5].TextureCoordinate = sVerts[2].TextureCoordinate;
            }
            return sVerts;
        }

        public void DrawPlatform(Texture2D podlogaTexture, Texture2D scianyTexture)
        {
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ProjectionMatrix;

            effect.TextureEnabled = true;
            effect.Texture = podlogaTexture;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, platformVerts, 0, 4); // The number of triangles to draw
            }
        }
    }
}
