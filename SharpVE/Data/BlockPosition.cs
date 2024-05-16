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

        /// <summary>
        /// Converts the global block position to a local position depending on chunk size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The local block position.</returns>
        public BlockPosition GetLocalPosition(ushort chunkSize)
        {
            var localX = X % chunkSize;
            var localY = Y % chunkSize;
            var localZ = Z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localY < 0) localY += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, localY, localZ);
        }

        /// <summary>
        /// Converts the global block position to a local position on the X and Z axis depending on chunk size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The horizontal local block position.</returns>
        public BlockPosition GetLocalHorizontalPosition(ushort chunkSize)
        {
            var localX = X % chunkSize;
            var localZ = Z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, Y, localZ);
        }

        /// <summary>
        /// Converts the global block position to a local position on the Y axis depending on chunk size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The vertical local block position.</returns>
        public BlockPosition GetLocalVerticalPosition(ushort chunkSize)
        {
            var localY = Y % chunkSize;

            if(localY < 0) localY += chunkSize;
            return new BlockPosition(X, localY, Z);
        }
    }
}
