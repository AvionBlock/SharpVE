using SharpVE.Data;
using SharpVE.Interfaces;
using System.Collections.Generic;

namespace SharpVE.Chunks
{
    public class ChunkManager<T> where T : class
    {
        private Dictionary<BlockPosition, ISubChunk<T>> chunks = new Dictionary<BlockPosition, ISubChunk<T>>();

        /// <summary>
        /// Creates a new <see cref="ISubChunk{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ISubChunk{T}"/>.</param>
        /// <param name="blockState">The blockstate to fill the <see cref="ISubChunk{T}"/>.</param>
        /// <returns>The created chunk.</returns>
        public ISubChunk<T> CreateChunk(BlockPosition position, T blockState)
        {
            var chunk = new SingleSubChunk<T>(blockState);
            chunks.Add(position, chunk);
            return chunk;
        }

        /// <summary>
        /// Adds a <see cref="ISubChunk{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ISubChunk{T}"/>.</param>
        /// <param name="chunk">The <see cref="ISubChunk{T}"/> to add.</param>
        public void AddChunk(BlockPosition position, ISubChunk<T> chunk)
        {
            chunks.Add(position, chunk);
        }

        /// <summary>
        /// Tries to add a <see cref="ISubChunk{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ISubChunk{T}"/>.</param>
        /// <param name="chunk">The <see cref="ISubChunk{T}"/> to add.</param>
        /// <returns>Whether the chunk has been added.</returns>
        public bool TryAddChunk(BlockPosition position, ISubChunk<T> chunk)
        {
            return chunks.TryAdd(position, chunk);
        }

        /// <summary>
        /// Get's a <see cref="ISubChunk{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ISubChunk{T}"/> to get.</param>
        /// <returns>The <see cref="ISubChunk{T}"/>.</returns>
        public ISubChunk<T> GetChunk(BlockPosition position)
        {
            return chunks[position];
        }

        /// <summary>
        /// Tries to get a <see cref="ISubChunk{T}"/>.
        /// </summary>
        /// <param name="position">The position of the <see cref="ISubChunk{T}"/> to get.</param>
        /// <returns>The <see cref="ISubChunk{T}"/>.</returns>
        public ISubChunk<T>? TryGetChunk(BlockPosition position)
        {
            chunks.TryGetValue(position, out var chunk);
            return chunk;
        }
    }
}
