using Silk.NET.OpenGL;
using System.Runtime.InteropServices;

namespace SharpVE.Graphics
{
    public class IBO
    {
        public uint ID { get; private set; }

        protected readonly GL GraphicsInstance;

        public IBO(GL gl)
        {
            ID = gl.GenBuffer();
            GraphicsInstance = gl;
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<uint> data)
        {
            var span = CollectionsMarshal.AsSpan(data);
            Bind();
            GraphicsInstance.BufferData(BufferTargetARB.ElementArrayBuffer, (ReadOnlySpan<uint>)span, BufferUsageARB.StaticDraw);
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
