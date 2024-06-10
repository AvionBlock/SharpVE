using SharpVE.Data;
using System.Collections.Generic;

namespace SharpVE.Chunks
{
    public class ChunkManager<T> where T : class
    {
        private Dictionary<ChunkPosition, ChunkColumn<T>> chunks = new Dictionary<ChunkPosition, ChunkColumn<T>>();

        public ChunkColumn<T> CreateChunk(ChunkPosition position, T blockState)
        {
            var chunk = new ChunkColumn<T>(blockState);
            chunks.Add(position, chunk);
            return chunk;
        }

        public void AddChunk(ChunkPosition position, ChunkColumn<T> chunkColumn)
        {
            chunks.Add(position, chunkColumn);
        }

        public bool TryAddChunk(ChunkPosition position, ChunkColumn<T> chunkColumn)
        {
            return chunks.TryAdd(position, chunkColumn);
        }

        public ChunkColumn<T> GetChunk(ChunkPosition position)
        {
            return chunks[position];
        }

        public ChunkColumn<T>? TryGetChunk(ChunkPosition position)
        {
            chunks.TryGetValue(position, out var chunk);
            return chunk;
        }
    }
}
