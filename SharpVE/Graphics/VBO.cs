using Silk.NET.Maths;
using Silk.NET.OpenGL;

namespace SharpVE.Graphics
{
    public class VBO
    {
        public uint ID { get; private set; }
        protected readonly GL GraphicsInstance;

        public VBO(GL gl)
        {
            ID = gl.GenBuffer();
            GraphicsInstance = gl;
        }

        /// <summary>
        /// Sets the 3D data of the VBO. Used for creating meshes.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<Vector3D<float>> data)
        {
            var Vertices = new float[data.Count * 3];
            for (int i = 0; i < data.Count; i++)
            {
                Vertices[i] = data[i].X;
                Vertices[i + 1] = data[i].Y;
                Vertices[i + 2] = data[i].Z;
            }
            Bind();
            fixed (void* v = &Vertices[0])
            {
                GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(data.Count * sizeof(float)), v, BufferUsageARB.StaticDraw);
            }
        }

        /// <summary>
        /// Sets the 2D data of the VBO. Used for applying textures.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<Vector2D<float>> data)
        {

        }

        public void Bind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ArrayBuffer, ID);
        }
    }
}
