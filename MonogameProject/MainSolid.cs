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

        /*public VertexPositionNormalTexture[] InitializeStation()
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
        }*/


        public VertexPositionNormalTexture[] InitializeStation()
        {
            VertexPositionNormalTexture[] sVerts = new VertexPositionNormalTexture[48];
            //podloga
            sVerts[0].Position = new Vector3(-(szerX / 2), -(dluY / 2), -wysokosc);
            sVerts[1].Position = new Vector3(-(szerX / 2), (dluY / 2), -wysokosc);
            sVerts[2].Position = new Vector3((szerX / 2), -(dluY / 2), -wysokosc);

            sVerts[3].Position = sVerts[1].Position;
            sVerts[4].Position = new Vector3((szerX / 2), (dluY / 2), -wysokosc);
            sVerts[5].Position = sVerts[2].Position;

            //przod
            sVerts[6].Position = new Vector3(-(szerX / 2), (dluY / 2), -wysokosc);//----
            sVerts[7].Position = new Vector3(-(szerX / 2), (dluY / 2), wysokosc);//----
            sVerts[8].Position = new Vector3((szerX / 4), (dluY / 2), -wysokosc);

            sVerts[9].Position = new Vector3(-(szerX / 2), (dluY / 2), wysokosc);
            sVerts[10].Position = new Vector3((szerX / 4), (dluY / 2), wysokosc);
            sVerts[11].Position = new Vector3((szerX / 4), (dluY / 2), -wysokosc);

            sVerts[12].Position = new Vector3((szerX / 4), (dluY / 2), -wysokosc);
            sVerts[13].Position = new Vector3((szerX / 4), (dluY / 2), wysokosc);
            sVerts[14].Position = sVerts[4].Position;

            sVerts[15].Position = new Vector3((szerX / 4), (dluY / 2), wysokosc);
            sVerts[16].Position = new Vector3((szerX / 2), (dluY / 2), wysokosc);//------
            sVerts[17].Position = sVerts[4].Position;///-------

            //prawasciana
            sVerts[18].Position = sVerts[4].Position;
            sVerts[19].Position = sVerts[16].Position;
            sVerts[20].Position = sVerts[2].Position;

            sVerts[21].Position = sVerts[16].Position;
            sVerts[22].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[23].Position = sVerts[2].Position;

            //lewa sciana
            sVerts[24].Position = sVerts[0].Position;
            sVerts[25].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[26].Position = sVerts[1].Position;

            sVerts[27].Position = sVerts[25].Position;
            sVerts[28].Position = new Vector3(-(szerX / 2), (dluY / 2), wysokosc);
            sVerts[29].Position = new Vector3(-(szerX / 2), (dluY / 2), -wysokosc);

            //tyl
            sVerts[30].Position = new Vector3((szerX / 2), -(dluY / 2), -wysokosc);
            sVerts[31].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[32].Position = new Vector3((szerX / 4), -(dluY / 2), -wysokosc);

            sVerts[33].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[34].Position = new Vector3((szerX / 4), -(dluY / 2), wysokosc);
            sVerts[35].Position = new Vector3((szerX / 4), -(dluY / 2), -wysokosc);

            sVerts[36].Position = new Vector3((szerX / 4), -(dluY / 2), -wysokosc);
            sVerts[37].Position = new Vector3((szerX / 4), -(dluY / 2), wysokosc);
            sVerts[38].Position = new Vector3(-(szerX / 2), -(dluY / 2), -wysokosc);

            sVerts[39].Position = new Vector3((szerX / 4), -(dluY / 2), wysokosc);
            sVerts[40].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[41].Position = new Vector3(-(szerX / 2), -(dluY / 2), -wysokosc);

            //sufit
            sVerts[42].Position = new Vector3(-(szerX / 2), (dluY / 2), wysokosc);
            sVerts[43].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[44].Position = new Vector3((szerX / 2), (dluY / 2), wysokosc);

            sVerts[45].Position = new Vector3(-(szerX / 2), -(dluY / 2), wysokosc);
            sVerts[46].Position = new Vector3((szerX / 2), -(dluY / 2), wysokosc);
            sVerts[47].Position = new Vector3((szerX / 2), (dluY / 2), wysokosc);

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
             
            }

            int repetitions = szerX/10;
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

        public void DrawStation(Texture2D podlogaTexture, Texture2D scianyTexture, Texture2D tunelTexture)
        {
            effect.View = camera.ViewMatrix;
            effect.Projection = camera.ProjectionMatrix;

            effect.TextureEnabled = true;

            List<VertexPositionNormalTexture> podloga = new List<VertexPositionNormalTexture>();
            List<VertexPositionNormalTexture> ptunel = new List<VertexPositionNormalTexture>();
            List<VertexPositionNormalTexture> reszta = new List<VertexPositionNormalTexture>();
  
            for (int i = 0; i < 48; i++ )
            {
                if(i<6)
                    podloga.Add(stationVerts[i]);
                else if(i>=6 && i <12)
                    reszta.Add(stationVerts[i]);
                else if(i >= 12 && i < 18)
                    ptunel.Add(stationVerts[i]);
                else if (i >= 30 && i < 36)
                    ptunel.Add(stationVerts[i]);
                else
                    reszta.Add(stationVerts[i]);
            }


            effect.Texture = podlogaTexture;
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, podloga.ToArray(), 0, 2); // The number of triangles to draw
            }
            effect.Texture = scianyTexture;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, reszta.ToArray(), 0, 10); // The number of triangles to draw
            }
            effect.Texture = tunelTexture;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, ptunel.ToArray(), 0, 4); // The number of triangles to draw
            }
        }
    }
}
