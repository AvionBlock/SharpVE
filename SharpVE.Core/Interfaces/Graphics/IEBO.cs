using System.Collections.Generic;

namespace SharpVE.Core.Interfaces.Graphics
{
    public interface IEBO
    {
        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="data"></param>
        void SetData(List<uint> data);

        /// <summary>
        /// Binds the buffer.
        /// </summary>
        void Bind();

        /// <summary>
        /// Unbinds the buffer.
        /// </summary>
        void Unbind();

        /// <summary>
        /// Deletes the EBO. Use this for disposing/cleaning up resources.
        /// </summary>
        void Delete();
    }
}
