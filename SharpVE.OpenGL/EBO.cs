using SharpVE.Core.Interfaces.Graphics;
using Silk.NET.OpenGL;
using System.Collections.Generic;
using System;

namespace SharpVE.OpenGL
{
    public class EBO : IEBO
    {
        private uint ID;
        protected readonly GL GraphicsInstance;

        public EBO(GL GraphicsInstance)
        {
            this.GraphicsInstance = GraphicsInstance;
            ID = GraphicsInstance.GenBuffer();
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<uint> data)
        {
            var span = new Span<uint>(data.ToArray());
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

        ~EBO()
        {
            Delete();
        }
    }
}
