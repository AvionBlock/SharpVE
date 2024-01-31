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

        /// <summary>
        /// Links a VBO to the VAO.
        /// </summary>
        /// <param name="location">Location slot inside the VAO.</param>
        /// <param name="size">Size of the slot e.g. 3D Vector is 3 floats therefore size is 3</param>
        /// <param name="vbo">The VBO to link.</param>
        public void LinkVBO(uint location, int size, VBO vbo)
        {
            vbo.Bind();
            unsafe
            {
                GraphicsInstance.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, null);
            }
            GraphicsInstance.EnableVertexAttribArray(location);
        }

        /// <summary>
        /// Binds the buffer.
        /// </summary>
        public void Bind()
        {
            GraphicsInstance.BindVertexArray(ID);
        }

        /// <summary>
        /// Unbinds the buffer.
        /// </summary>
        public void Unbind()
        {
            GraphicsInstance.BindVertexArray(0);
        }

        /// <summary>
        /// Deletes the VBO. Use this for disposing/cleaning up resources.
        /// </summary>
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
