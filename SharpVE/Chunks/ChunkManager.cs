using SharpVE.Data;
using System.Collections.Generic;

namespace SharpVE.Chunks
{
    public class ChunkManager<T> where T : class
    {
        private Dictionary<ChunkPosition, ChunkColumn<T>> chunks = new Dictionary<ChunkPosition, ChunkColumn<T>>();

        /// <summary>
        /// Creates a new <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ChunkColumn{T}"/>.</param>
        /// <param name="blockState">The blockstate to fill teh <see cref="ChunkColumn{T}"/>.</param>
        /// <returns>The created chunk column.</returns>
        public ChunkColumn<T> CreateChunk(ChunkPosition position, T blockState)
        {
            var chunk = new ChunkColumn<T>(blockState);
            chunks.Add(position, chunk);
            return chunk;
        }

        /// <summary>
        /// Adds a <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ChunkColumn{T}"/>.</param>
        /// <param name="chunkColumn">The <see cref="ChunkColumn{T}"/> to add.</param>
        public void AddChunk(ChunkPosition position, ChunkColumn<T> chunkColumn)
        {
            chunks.Add(position, chunkColumn);
        }

        /// <summary>
        /// Tries to add a <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ChunkColumn{T}"/>.</param>
        /// <param name="chunkColumn">The <see cref="ChunkColumn{T}"/> to add.</param>
        /// <returns>Whether the chunk column has been added.</returns>
        public bool TryAddChunk(ChunkPosition position, ChunkColumn<T> chunkColumn)
        {
            return chunks.TryAdd(position, chunkColumn);
        }

        /// <summary>
        /// Get's a <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ChunkColumn{T}"/> to get.</param>
        /// <returns>The <see cref="ChunkColumn{T}"/>.</returns>
        public ChunkColumn<T> GetChunk(ChunkPosition position)
        {
            return chunks[position];
        }

        /// <summary>
        /// Tries to get a <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ChunkColumn{T}"/> to get.</param>
        /// <returns>The <see cref="ChunkColumn{T}"/>.</returns>
        public ChunkColumn<T>? TryGetChunk(ChunkPosition position)
        {
            chunks.TryGetValue(position, out var chunk);
            return chunk;
        }
    }
}
