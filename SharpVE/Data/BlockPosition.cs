namespace SharpVE.Data
{
    public struct BlockPosition
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public int Y;

        /// <summary>
        /// The Z coordinate.
        /// </summary>
        public int Z;

        /// <summary>
        /// Constructs a new block position.
        /// </summary>
        /// <param name="x">The X coordinate of the block.</param>
        /// <param name="y">The Y coordinate of the block.</param>
        /// <param name="z">The Z coordinate of the block.</param>
        public BlockPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
