using SharpVE.Interfaces;

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
        /// Converts the global block position to a local position depending on the <see cref="ISubChunk{T}"/> size.
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
        /// Converts the global block position to a local position on the X and Z axis depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The horizontal local block position.</returns>
        public BlockPosition GetLocalXZPosition(ushort chunkSize)
        {
            var localX = X % chunkSize;
            var localZ = Z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, Y, localZ);
        }

        /// <summary>
        /// Converts the global block position to a local position on the Y axis depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The vertical local block position.</returns>
        public BlockPosition GetLocalYPosition(ushort chunkSize)
        {
            var localY = Y % chunkSize;

            if(localY < 0) localY += chunkSize;
            return new BlockPosition(X, localY, Z);
        }

        /// <summary>
        /// Converts a global block position to a local position depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The local block position.</returns>
        public static BlockPosition ToLocalPosition(BlockPosition position, ushort chunkSize)
        {
            var localX = position.X % chunkSize;
            var localY = position.Y % chunkSize;
            var localZ = position.Z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localY < 0) localY += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, localY, localZ);
        }

        /// <summary>
        /// Converts a global block position to a local position on the X and Z axis depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The horizontal local block position.</returns>
        public static BlockPosition ToLocalXZPosition(BlockPosition position, ushort chunkSize)
        {
            var localX = position.X % chunkSize;
            var localZ = position.Z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, position.Y, localZ);
        }

        /// <summary>
        /// Converts a global block position to a local position on the Y axis depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="position">The global <see cref="BlockPosition"/> to convert.</param>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The vertical local block position.</returns>
        public static BlockPosition ToLocalYPosition(BlockPosition position, ushort chunkSize)
        {
            var localY = position.Y % chunkSize;

            if (localY < 0) localY += chunkSize;
            return new BlockPosition(position.X, localY, position.Z);
        }

        /// <summary>
        /// Converts the global block position to a local position depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="x">The global X position to convert.</param>
        /// <param name="y">The global Y position to convert.</param>
        /// <param name="z">The global Z position to convert.</param>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The local block position.</returns>
        public static BlockPosition ToLocalPosition(int x, int y, int z, ushort chunkSize)
        {
            var localX = x % chunkSize;
            var localY = y % chunkSize;
            var localZ = z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localY < 0) localY += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, localY, localZ);
        }

        /// <summary>
        /// Converts the global block position to a local position on the X and Z axis depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="x">The global X position to convert.</param>
        /// <param name="z">The global Z position to convert.</param>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The horizontal local block position.</returns>
        public static BlockPosition ToLocalXZPosition(int x, int z, ushort chunkSize)
        {
            var localX = x % chunkSize;
            var localZ = z % chunkSize;

            if (localX < 0) localX += chunkSize;
            if (localZ < 0) localZ += chunkSize;

            return new BlockPosition(localX, 0, localZ);
        }

        /// <summary>
        /// Converts the global block position to a local position on the Y axis depending on the <see cref="ISubChunk{T}"/> size.
        /// </summary>
        /// <param name="y">The global Y position to convert.</param>
        /// <param name="chunkSize">The chunk size (subchunk size).</param>
        /// <returns>The vertical local block position.</returns>
        public static BlockPosition ToLocalYPosition(int y, ushort chunkSize)
        {
            var localY = y % chunkSize;

            if (localY < 0) localY += chunkSize;
            return new BlockPosition(0, localY, 0);
        }
    }
}
