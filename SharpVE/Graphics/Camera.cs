using Silk.NET.Maths;

namespace SharpVE.Graphics
{
    public class Camera
    {
        #region Camera Controls
        public float FOV = 45f;
        public float Speed = 8f;
        public float Sensitivity = 30f;
        public float Pitch;
        public float Yaw;

        public Vector3D<float> Position;
        public Vector2D<float> LastPosition { get; private set; }
        #endregion

        #region Camera Information
        public Matrix4X4<float> ProjectionMatrix { get; private set; }
        private float ScreenWidth;
        private float ScreenHeight;

        private Vector3D<float> Up = Vector3D<float>.UnitY;
        private Vector3D<float> Forward = -Vector3D<float>.UnitZ;
        private Vector3D<float> Right = Vector3D<float>.UnitX;

        private bool FirstMove = true;
        #endregion

        public Camera(float screenWidth, float screenHeight)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            ProjectionMatrix = Matrix4X4.CreatePerspectiveFieldOfView(FOV * MathF.PI / 180, ScreenWidth / ScreenHeight, 0.1f, 100f);
        }

        #region Public Methods
        public void UpdateScreen(float screenWidth, float screenHeight)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            ProjectionMatrix = Matrix4X4.CreatePerspectiveFieldOfView(FOV * MathF.PI / 180, ScreenWidth / ScreenHeight, 0.1f, 100f);
        }

        public Matrix4X4<float> GetViewMatrix()
        {
            return Matrix4X4.CreateLookAt(Position, Position + Forward, Up);
        }
        #endregion

        #region Private Methods
        private void UpdateVectors()
        {
            if (Pitch > 89.0f)
            {
                Pitch = 89.0f;
            }
            if (Pitch < -89.0f)
            {
                Pitch = -89.0f;
            }

            Forward.X = MathF.Cos(Pitch * MathF.PI / 180) * MathF.Cos(Yaw * MathF.PI / 180);
            Forward.Y = MathF.Sin(Pitch * MathF.PI / 180);
            Forward.Z = MathF.Cos(Pitch * MathF.PI / 180) * MathF.Sin(Yaw * MathF.PI / 180);

            Forward = Vector3D.Normalize(Forward);

            Right = Vector3D.Normalize(Vector3D.Cross(Forward, Vector3D<float>.UnitY));
            Up = Vector3D.Normalize(Vector3D.Cross(Right, Forward));
        }
        #endregion
    }
}
