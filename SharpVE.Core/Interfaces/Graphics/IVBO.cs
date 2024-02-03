using Silk.NET.Maths;
using System.Collections.Generic;

namespace SharpVE.Core.Interfaces.Graphics
{
    public interface IVBO
    {
        /// <summary>
        /// Sets the 3D data of the VBO. Used for creating meshes or normals.
        /// </summary>
        /// <param name="data"></param>
        void SetData(List<Vector3D<float>> data);

        /// <summary>
        /// Sets the 2D data of the VBO. Used for defining a texture.
        /// </summary>
        /// <param name="data"></param>
        void SetData(List<Vector2D<float>> data);

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
