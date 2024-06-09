using SharpVE.Data;
using SharpVE.Interfaces;
using System.Collections.Generic;

namespace SharpVE.Chunks
{
    public class ChunkManager<T> where T : class
    {
        private Dictionary<ChunkPosition, IChunkColumn<T>> chunks = new Dictionary<ChunkPosition, IChunkColumn<T>>();

        public IChunkColumn<T> CreateChunk(ChunkPosition position)
        {
            var chunk = new ChunkColumn<T>();
            chunks.Add(position, chunk);
            return chunk;
        }

        public IChunkColumn<T> CreateChunk(ChunkPosition position, T blockState)
        {
            var chunk = new ChunkColumn<T>(blockState);
            chunks.Add(position, chunk);
            return chunk;
        }

        public void AddChunk(ChunkPosition position, IChunkColumn<T> chunkColumn)
        {
            chunks.Add(position, chunkColumn);
        }

        public bool TryAddChunk(ChunkPosition position, IChunkColumn<T> chunkColumn)
        {
            return chunks.TryAdd(position, chunkColumn);
        }

        public IChunkColumn<T> GetChunk(ChunkPosition position)
        {
            return chunks[position];
        }

        public IChunkColumn<T>? TryGetChunk(ChunkPosition position)
        {
            chunks.TryGetValue(position, out var chunk);
            return chunk;
        }
    }
}
