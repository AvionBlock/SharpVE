using Silk.NET.OpenGL;

namespace SharpVE.Graphics
{
    public class IBO
    {
        public uint ID { get; private set; }
        public int Length => Indices.Length;
        private uint[] Indices;

        protected readonly GL GraphicsInstance;

        public IBO(GL gl)
        {
            ID = gl.GenBuffer();
            GraphicsInstance = gl;
            Indices = new uint[0];
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<uint> data)
        {
            Indices = data.ToArray();
            Bind();
            unsafe
            {
                fixed (void* i = &Indices[0])
                {
                    GraphicsInstance.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(Indices.Length * sizeof(uint)), i, BufferUsageARB.StaticDraw);
                }
            }
        }

        /// <summary>
        /// Binds the buffer.
        /// </summary>
        public void Bind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ElementArrayBuffer, ID);
        }

        /// <summary>
        /// Unbinds the buffer.
        /// </summary>
        public void Unbind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// Deletes the IBO. Use this for disposing/cleaning up resources.
        /// </summary>
        public void Delete()
        {
            GraphicsInstance.DeleteBuffer(ID);
        }

        ~IBO()
        {
            Delete();
        }
    }
}
