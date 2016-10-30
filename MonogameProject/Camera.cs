using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameProject
{
    public class Camera
    {
        // We need this to calculate the aspectRatio
        // in the ProjectionMatrix property.
        GraphicsDevice graphicsDevice;

        Vector3 position = new Vector3(0, -50, 10);
        
        float angleZ, angleX;
        
        public Matrix ViewMatrix
        {
            get
            {   
                var lookAtVector = new Vector3(0, 1, -0.1f);

                var rotationMatrix = Matrix.CreateRotationZ(angleZ);
                var rotationMatrix2 = Matrix.CreateRotationX(angleX);
                lookAtVector = Vector3.Transform(lookAtVector, rotationMatrix);
                lookAtVector = Vector3.Transform(lookAtVector, rotationMatrix2);
                lookAtVector += position;

                var upVector = Vector3.UnitZ;

                return Matrix.CreateLookAt(
                    position, lookAtVector, upVector);
            }
        }

        public Matrix ProjectionMatrix
        {
            get
            {
                float fieldOfView = Microsoft.Xna.Framework.MathHelper.PiOver4;
                float nearClipPlane = 1;
                float farClipPlane = 200;
                float aspectRatio = graphicsDevice.Viewport.Width / (float)graphicsDevice.Viewport.Height;

                return Matrix.CreatePerspectiveFieldOfView(
                    fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
            }
        }

        public Camera(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public void Update(GameTime gameTime)
        {
            ////---------------------LEWO PRAWO GORA DOL
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 1.0f;
                position.Y -= (float)Math.Sin((double)angleZ);
                position.Z += (float)Math.Sin((double)angleX);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1.0f;
                position.Y += (float)Math.Sin((double)angleZ);
                position.Z -= (float)Math.Sin((double)angleX);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y += 1.0f;
                position.X -= (float)Math.Sin((double)angleZ);
                position.Z += (float)Math.Sin((double)angleX);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y -= 1.0f;
                position.X += (float)Math.Sin((double)angleZ);
                position.Z -= (float)Math.Sin((double)angleX);
            }
            ////----------------------PRZOD TYL
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                position.Z += 0.5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {
                position.Z -= 0.5f;
            }

            ////--------------------OBROTY LEWO PRAWO GORA DOL
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                angleX += 0.02f;
                            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                angleX -= 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                angleZ += 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                angleZ -= 0.02f;
            }
        }
    }
}
