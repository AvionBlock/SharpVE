using Silk.NET.Maths;
using Silk.NET.OpenGL;
using System.Runtime.InteropServices;

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
            var span = CollectionsMarshal.AsSpan(data);
            var vertices = MemoryMarshal.Cast<Vector3D<float>, float>(span).ToArray();
            Bind();
            //Yup, Using pointers is apparently UNSAFE
            unsafe
            {
                fixed (void* v = &vertices[0])
                {
                    GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), v, BufferUsageARB.StaticDraw);
                }
            }
            Unbind();
        }

        /// <summary>
        /// Sets the 2D data of the VBO. Used for applying textures.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<Vector2D<float>> data)
        {
            var span = CollectionsMarshal.AsSpan(data);
            var vertices = MemoryMarshal.Cast<Vector2D<float>, float>(span).ToArray();
            Bind();
            //Yup, Using pointers is apparently UNSAFE
            unsafe
            {
                fixed (void* v = &vertices[0])
                {
                    GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), v, BufferUsageARB.StaticDraw);
                }
            }
            Unbind();
        }

        /// <summary>
        /// Binds the buffer.
        /// </summary>
        public void Bind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ArrayBuffer, ID);
        }

        /// <summary>
        /// Unbinds the buffer.
        /// </summary>
        public void Unbind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
        }

        /// <summary>
        /// Deletes the VBO. Use this for disposing/cleaning up resources.
        /// </summary>
        public void Delete()
        {
            GraphicsInstance.DeleteBuffer(ID);
        }
        
        //I actually dunno if I need this...
        ~VBO()
        {
            Delete();
        }
    }
}
