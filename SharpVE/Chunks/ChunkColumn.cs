using SharpVE.Chunks;
using SharpVE.Data;
using SharpVE.Interfaces;
using System;

namespace SharpVE.World.Chunks
{
    /// <summary>
    /// A chunk column.
    /// </summary>
    public class ChunkColumn<T> : IChunkColumn<T>
    {
        /// <summary>
        /// The chunk position.
        /// </summary>
        public ChunkPosition Position { get; private set; }

        /// <summary>
        /// The subchunks/sections that make up the chunk column.
        /// </summary>
        public ISubChunk<T>[] SubChunks { get; private set; } 

        /// <summary>
        /// Constructs a new chunk column.
        /// </summary>
        /// <param name="x">The X coordinate of the chunk column.</param>
        /// <param name="y">The Y coordinate of the chunk column.</param>
        /// <param name="minY">The minimum Y coordinate of the chunk column.</param>
        /// <param name="maxY">The maximum Y coordinate of the chunk column.</param>
        /// <param name="defaultBlockState">The default block state to set when the chunk column is created.</param>
        public ChunkColumn(T defaultBlockState, int x, int y)
        {
            Position = new ChunkPosition(x, y);
            SubChunks = new SubChunk<T>[(int)(MathF.Ceiling(IChunkColumn<T>.ColumnHeight))];
            for (int i = 0; i < SubChunks.Length; i++)
            {
                SubChunks[i] = new SingleSubChunk<T>(defaultBlockState);
            }
        }
    }
}
