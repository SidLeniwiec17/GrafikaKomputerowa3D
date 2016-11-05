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

        /* Vector3 position = new Vector3(0, -50, 10);
        float angleZ, angleX;*/

        //------------------------------------------------------------------------
        Vector3 cameraPosition = new Vector3(2.0f, -4.0f, 2.0f);
        float leftrightRot = - MathHelper.PiOver2;
        float updownRot = -MathHelper.Pi / 10.0f;
        const float rotationSpeed = 0.3f;
        const float moveSpeed = 1.0f;
        public Matrix ViewMatrix;
        //------------------------------------------------------------------------

        /* public Matrix ViewMatrix
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
         */
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
            Vector3 moveVector = new Vector3(0, 0, 0);

            ////---------------------LEWO PRAWO GORA DOL
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                moveVector += new Vector3(-1, 0, 0);
                /*position.X -= 1.0f;
                position.Y -= (float)Math.Sin((double)angleZ);
                position.Z += (float)Math.Sin((double)angleX);*/
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                moveVector += new Vector3(1, 0, 0);
                /*position.X += 1.0f;
                position.Y += (float)Math.Sin((double)angleZ);
                position.Z -= (float)Math.Sin((double)angleX);*/
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                moveVector += new Vector3(0, 1, 0);
                /*position.Y += 1.0f;
                position.X -= (float)Math.Sin((double)angleZ);
                position.Z += (float)Math.Sin((double)angleX);*/
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                moveVector += new Vector3(0, -1, 0);
                /*position.Y -= 1.0f;
                position.X += (float)Math.Sin((double)angleZ);
                position.Z -= (float)Math.Sin((double)angleX);*/
            }
            ////----------------------PRZOD TYL
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                moveVector += new Vector3(0, 0, 1);
                //position.Z += 0.5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {

                moveVector += new Vector3(0, 0, -1);   
                //position.Z -= 0.5f;
            }

            ////--------------------OBROTY LEWO PRAWO GORA DOL
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                updownRot += 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                updownRot -= 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                leftrightRot += 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                leftrightRot -= 0.02f;
            }

            AddToCameraPosition(moveVector, gameTime);
        }


        //------------------------------------------------------------------------
        private void AddToCameraPosition(Vector3 vectorToAdd, GameTime gameTime)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationZ(leftrightRot);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            cameraPosition += moveSpeed * rotatedVector;
            UpdateViewMatrix();
        }
        private void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationZ(leftrightRot);

            //Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraOriginalTarget = new Vector3(0, 1, 0);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;
            
            //Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraOriginalUpVector = new Vector3(0, 0, 1);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            ViewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }
        //------------------------------------------------------------------------
    }
}
