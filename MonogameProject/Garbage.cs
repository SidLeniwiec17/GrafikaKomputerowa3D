﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonogameProject
{
    public class Garbage
    {
        Model smietnik;
        int posX = 0;
        int posY = 0;

        public void Initialize(ContentManager contentManager, int x, int y)
        {
            smietnik = contentManager.Load<Model>("Garbage_Container_");
            posX = x;
            posY = y;
        }

        public void Draw(Camera camera, float aspectRatio)
        {
            foreach (var mesh in smietnik.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    //effect.PreferPerPixelLighting = true;

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
            float scale = 1.0f;
            // this matrix moves the model "out" from the origin
            Matrix translationMatrix = Matrix.CreateTranslation(posX, posY, -5);

            // this matrix rotates everything around the origin
            //Matrix rotationMatrix = Matrix.CreateRotationZ((float)Math.PI );

            // We combine the two to have the model move in a circle:
            Matrix combined = Matrix.CreateScale(scale) * translationMatrix ;

            return combined;
        }
    }
}