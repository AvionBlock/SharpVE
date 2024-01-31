using SharpVE.Core.Interfaces.Graphics;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace SharpVE.OpenGL
{
    public class VBO : IVBO
    {
        public readonly uint ID;
        protected readonly GL GraphicsInstance;

        public VBO(GL GraphicsInstance)
        {
            this.GraphicsInstance = GraphicsInstance;
            ID = GraphicsInstance.GenBuffer();
        }

        /// <summary>
        /// Sets the 3D data of the VBO. Used for creating meshes or normals.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<Vector3D<float>> data)
        {
            var span = new Span<Vector3D<float>>(data.ToArray());
            var vertices = MemoryMarshal.Cast<Vector3D<float>, float>(span);

            Bind();
            GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (ReadOnlySpan<float>)vertices, BufferUsageARB.StaticDraw);
            Unbind();
        }

        /// <summary>
        /// Sets the 2D data of the VBO. Used for defining a texture.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<Vector2D<float>> data)
        {
            var span = new Span<Vector2D<float>>(data.ToArray());
            var vertices = MemoryMarshal.Cast<Vector2D<float>, float>(span);

            Bind();
            GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (ReadOnlySpan<float>)vertices, BufferUsageARB.StaticDraw);
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
