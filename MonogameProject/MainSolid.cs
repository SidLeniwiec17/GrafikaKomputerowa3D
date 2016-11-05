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
        VertexPositionNormalTexture[] stationVerts;
        int szerX;
        int dluY;
        int wysokosc = 8;
        
        public MainSolid(BasicEffect _effect, Camera _camera, GraphicsDeviceManager _graphics, int _szer, int _dlug)
        {
            effect = _effect;
            camera = _camera;
            graphics = _graphics;
            szerX = _szer;
            dluY = _dlug; 
            stationVerts = InitializeStation();
        }

        public VertexPositionNormalTexture[] InitializeStation()
        {
            VertexPositionNormalTexture[] sVerts = new VertexPositionNormalTexture[36];
            //podloga
            sVerts[0].Position = new Vector3(-(szerX / 2), -(dluY / 2), -wysokosc);
            sVerts[1].Position = new Vector3(-(szerX / 2), (dluY / 2), -wysokosc);
            sVerts[2].Position = new Vector3((szerX / 2), -(dluY / 2), -wysokosc);

            sVerts[3].Position = sVerts[1].Position;
            sVerts[4].Position = new Vector3((szerX / 2), (dluY / 2), -wysokosc);
            sVerts[5].Position = sVerts[2].Position;

            //przod
            sVerts[6].Position = sVerts[1].Position;
            sVerts[7].Position = new Vector3(-(szerX / 2), (dluY / 2), wysokosc);
            sVerts[8].Position = sVerts[4].Position;

            sVerts[9].Position = sVerts[7].Position;
            sVerts[10].Position = new Vector3((szerX / 2), (dluY / 2), wysokosc);
            sVerts[11].Position = sVerts[8].Position;

            //prawasciana
            sVerts[12].Position = sVerts[4].Position;
            sVerts[13].Position = sVerts[10].Position;
            sVerts[14].Position = sVerts[2].Position;

            sVerts[15].Position = sVerts[10].Position;
            sVerts[16].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[17].Position = sVerts[2].Position;
            
            //lewa sciana
            sVerts[18].Position = sVerts[0].Position;
            sVerts[19].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[20].Position = sVerts[1].Position;

            sVerts[21].Position = sVerts[19].Position;
            sVerts[22].Position = sVerts[7].Position;
            sVerts[23].Position = sVerts[1].Position;

            //tyl
            sVerts[24].Position = sVerts[2].Position;
            sVerts[25].Position = sVerts[16].Position;
            sVerts[26].Position = sVerts[0].Position;

            sVerts[27].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[28].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[29].Position = new Vector3(-(szerX / 2), -(dluY / 2), -wysokosc);
                    
            //sufit
            sVerts[30].Position = new Vector3(-(szerX / 2), (dluY / 2), wysokosc);
            sVerts[31].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[32].Position = new Vector3((szerX / 2), (dluY / 2), wysokosc);

            sVerts[33].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[34].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[35].Position = new Vector3((szerX / 2), (dluY / 2), wysokosc);

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

            int repetitions = szerX;
            for (int i = 0; i < sVerts.Length ; i = i + 6)
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

        public void DrawStation(Texture2D podlogaTexture, Texture2D scianyTexture)
        {
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ProjectionMatrix;

            effect.TextureEnabled = true;
            effect.Texture = podlogaTexture;

            VertexPositionNormalTexture[] podloga = new VertexPositionNormalTexture[6];
            VertexPositionNormalTexture[] reszta = new VertexPositionNormalTexture[30];
            for (int i = 0; i < 6; i++)
                podloga[i] = stationVerts[i];

            for (int i = 0; i < 30; i++)
                reszta[i] = stationVerts[i+6];

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, podloga, 0, 2); // The number of triangles to draw
            }
            effect.Texture = scianyTexture;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, reszta, 0, 10); // The number of triangles to draw
            }
        }
    }
}
