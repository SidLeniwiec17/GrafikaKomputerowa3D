using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonogameProject
{
    public class Bench
    {
        Model lawka;

        public void Initialize(ContentManager contentManager)
        {
            lawka = contentManager.Load<Model>("bench_res");
        }

        public void Draw(Camera camera)
        {
            foreach (var mesh in lawka.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;

                    effect.World = Matrix.Identity;
                    effect.View = camera.ViewMatrix;
                    effect.Projection = camera.ProjectionMatrix;
                }

                mesh.Draw();
            }
        }
    }
}