namespace SharpVE.Core.Interfaces.Graphics
{
    public interface IVAO
    {
        /// <summary>
        /// Links a VBO to the VAO.
        /// </summary>
        /// <param name="location">Location slot inside the VAO.</param>
        /// <param name="size">Size of the slot e.g. 3D Vector is 3 floats therefore size is 3</param>
        /// <param name="vbo">The VBO to link.</param>
        void LinkVBO(uint location, int size, IVBO vbo);

        /// <summary>
        /// Binds the buffer.
        /// </summary>
        void Bind();

        /// <summary>
        /// Unbinds the buffer.
        /// </summary>
        void Unbind();

        /// <summary>
        /// Deletes the VBO. Use this for disposing/cleaning up resources.
        /// </summary>
        void Delete();
    }
}
