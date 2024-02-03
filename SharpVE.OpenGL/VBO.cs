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

        public void SetData(List<Vector3D<float>> data)
        {
            var span = new Span<Vector3D<float>>(data.ToArray());
            var vertices = MemoryMarshal.Cast<Vector3D<float>, float>(span);

            Bind();
            GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (ReadOnlySpan<float>)vertices, BufferUsageARB.StaticDraw);
            Unbind();
        }

        public void SetData(List<Vector2D<float>> data)
        {
            var span = new Span<Vector2D<float>>(data.ToArray());
            var vertices = MemoryMarshal.Cast<Vector2D<float>, float>(span);

            Bind();
            GraphicsInstance.BufferData(BufferTargetARB.ArrayBuffer, (ReadOnlySpan<float>)vertices, BufferUsageARB.StaticDraw);
            Unbind();
        }

        public void Bind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ArrayBuffer, ID);
        }

        public void Unbind()
        {
            GraphicsInstance.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
        }

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
