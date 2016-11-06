using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonogameProject
{
    public class Bench
    {
        Model lawka;
        int posX = 0;
        int posY = 0;

        public void Initialize(ContentManager contentManager, int ws1, int ws2)
        {
            //lawka = contentManager.Load<Model>("bench_res");
            lawka = contentManager.Load<Model>("benches");
            posX = ws2;
            posY = -ws1;
        }

        public void Draw(Camera camera, float aspectRatio)
        {
            foreach (var mesh in lawka.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;

                    effect.World = GetWorldMatrix();

                    effect.View = camera.ViewMatrix;

                    float fieldOfView = Microsoft.Xna.Framework.MathHelper.PiOver4;
                    float nearClipPlane = 1;
                    float farClipPlane = 200;

                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
                }

                mesh.Draw();
            }
        }
        Matrix GetWorldMatrix()
        {
            float scale = 0.05f;
            // this matrix moves the model "out" from the origin
            Matrix translationMatrix = Matrix.CreateTranslation(posX, posY, -5);

            // this matrix rotates everything around the origin
            Matrix rotationMatrix = Matrix.CreateRotationZ((float)Math.PI/2);

            // We combine the two to have the model move in a circle:
            Matrix combined = Matrix.CreateScale(scale) * translationMatrix * rotationMatrix;

            return combined;
        }
    }
}