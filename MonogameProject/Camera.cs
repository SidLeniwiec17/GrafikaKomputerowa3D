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
       
        GraphicsDevice graphicsDevice;
        //------------------------------------------------------------------------
        public Vector3 cameraPosition = new Vector3(2.0f, -4.0f, 2.0f);
        float leftrightRot = 0.0f;
        float updownRot = 0.0f;//-MathHelper.Pi / 10.0f;
        float clockwiseRot = 0.0f;
        const float rotationSpeed = 0.4f;
        const float moveSpeed = 20.0f;
        public Matrix ViewMatrix;
        int sceneSizeX, sceneSizeY;
        bool blokada = true;
        //------------------------------------------------------------------------

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

        public Camera(GraphicsDevice graphicsDevice, int _sceneSizeX, int _sceneSizeY)
        {
            this.graphicsDevice = graphicsDevice;
            sceneSizeX = _sceneSizeX;
            sceneSizeY = _sceneSizeY;
        }

        public void Update(GameTime gameTime)
        {
            Vector3 moveVector = new Vector3(0, 0, 0);

            ////---------------------LEWO PRAWO GORA DOL
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                moveVector += new Vector3(-1, 0, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                moveVector += new Vector3(1, 0, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                moveVector += new Vector3(0, 1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                moveVector += new Vector3(0, -1, 0);
            }
            ////----------------------PRZOD TYL
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                moveVector += new Vector3(0, 0, 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {
                moveVector += new Vector3(0, 0, -1);   
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
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                clockwiseRot -= 0.02f;
            } 
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                clockwiseRot += 0.02f;
            }
            UpdateViewMatrix(moveVector, gameTime);
        }
        private void UpdateViewMatrix(Vector3 vectorToAdd, GameTime gameTime)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(clockwiseRot) * Matrix.CreateRotationZ(leftrightRot);
           
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            cameraPosition += (moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds )* rotatedVector;
            
            if (blokada)
            {
                if (cameraPosition.X < -sceneSizeX / 2 + 1)
                    cameraPosition.X = -sceneSizeX / 2 + 1;
                if (cameraPosition.X > sceneSizeX / 2 - 1)
                    cameraPosition.X = sceneSizeX / 2 - 1;

                if (cameraPosition.Y < -sceneSizeY / 2 + 1)
                    cameraPosition.Y = -sceneSizeY / 2 + 1;
                if (cameraPosition.Y > sceneSizeY / 2 - 1)
                    cameraPosition.Y = sceneSizeY / 2 - 1;

                if (cameraPosition.Z < -4 && cameraPosition.X < (sceneSizeX / 4))
                    cameraPosition.Z = -4;
                if (cameraPosition.Z < -7 && cameraPosition.X > (sceneSizeX / 4))
                    cameraPosition.Z = -7;

                if (cameraPosition.Z > 7)
                    cameraPosition.Z = 7;
            }

            Vector3 cameraOriginalTarget = new Vector3(0, 1, 0);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;
            
            Vector3 cameraOriginalUpVector = new Vector3(0, 0, 1);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            ViewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }
        //------------------------------------------------------------------------
    }
}
