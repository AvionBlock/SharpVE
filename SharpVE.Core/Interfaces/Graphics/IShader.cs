namespace SharpVE.Core.Interfaces.Graphics
{
    public interface IShader
    {
        /// <summary>
        /// ID of the shader.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Uses the shader before drawing to screen.
        /// </summary>
        public void Use();

        /// <summary>
        /// Deletes/Disposes the shader.
        /// </summary>
        public void Delete();
    }
}
