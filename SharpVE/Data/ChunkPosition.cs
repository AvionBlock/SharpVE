using System;

namespace SharpVE.Data
{
    /// <summary>
    /// A chunk position.
    /// </summary>
    public struct ChunkPosition
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public int X;

        /// <summary>
        /// The Z coordinate.
        /// </summary>
        public int Z;

        /// <summary>
        /// A chunk position.
        /// </summary>
        /// <param name="x">Chunk X coordinate.</param>
        /// <param name="z">Chunk Z coordinate.</param>
        public ChunkPosition(int x, int z)
        {
            X = x;
            Z = z;
        }

        /// <summary>
        /// Converts a block position to a chunk coordinate.
        /// </summary>
        /// <param name="blockPosition">The block position.</param>
        /// <param name="chunkSize">The chunk size in blocks on one side.</param>
        /// <returns></returns>
        public static ChunkPosition FromBlockPosition(BlockPosition blockPosition, ushort chunkSize)
        {
            //Calculate the X and Z coord of the chunk column from the global position.
            var xCoord = (int)MathF.Floor(blockPosition.X / chunkSize);
            var zCoord = (int)MathF.Floor(blockPosition.Z / chunkSize);
            return new ChunkPosition(xCoord, zCoord);
        }
    }
}
