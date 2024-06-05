using SharpVE.Chunks;
using SharpVE.Data;

namespace SharpVE.World.Chunks
{
    /// <summary>
    /// A chunk column.
    /// </summary>
    public class ChunkColumn<T>
    {
        /// <summary>
        /// The chunk position.
        /// </summary>
        public ChunkPosition Position { get; private set; }

        /// <summary>
        /// The subchunks/sections that make up the chunk column.
        /// </summary>
        public SubChunk<T>[] SubChunks { get; private set; } 

        /// <summary>
        /// Constructs a new chunk column.
        /// </summary>
        /// <param name="x">The X coordinate of the chunk column.</param>
        /// <param name="y">The Y coordinate of the chunk column.</param>
        /// <param name="minY">The minimum Y coordinate of the chunk column.</param>
        /// <param name="maxY">The maximum Y coordinate of the chunk column.</param>
        /// <param name="defaultBlockState">The default block state to set when the chunk column is created.</param>
        public ChunkColumn(int x, int y, int minY, int maxY, T defaultBlockState)
        {
            var chunkColumnHeight = maxY - minY;
            Position = new ChunkPosition(x, y);
        }
    }
}
