using SharpVE.Data;
using SharpVE.Interfaces;

namespace SharpVE.Chunks
{
    public class SingleChunkColumn<T> : IChunkColumn<T> where T : class
    {
        public ChunkPosition Position { get; private set; }
    }
}
