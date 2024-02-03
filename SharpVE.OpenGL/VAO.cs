using SharpVE.Core.Interfaces.Graphics;
using Silk.NET.OpenGL;

namespace SharpVE.OpenGL
{
    public class VAO : IVAO
    {
        public uint ID { get; private set; }
        protected readonly GL GraphicsInstance;

        public VAO(GL gl)
        {
            ID = gl.GenVertexArray();
            GraphicsInstance = gl;
        }

        public void LinkVBO(uint location, int size, IVBO vbo)
        {
            vbo.Bind();
            unsafe
            {
                GraphicsInstance.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, null);
            }
            GraphicsInstance.EnableVertexAttribArray(location);
        }

        public void Bind()
        {
            GraphicsInstance.BindVertexArray(ID);
        }

        public void Unbind()
        {
            GraphicsInstance.BindVertexArray(0);
        }

        public void Delete()
        {
            GraphicsInstance.DeleteVertexArray(ID);
        }

        ~VAO()
        {
            Delete();
        }
    }
}
