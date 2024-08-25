using SharpVE.Chunks;

namespace SharpVE
{
    public class World<T> where T : class
    {
        public ChunkManager<T> ChunkManager { get; }

        public World()
        {
            ChunkManager = new ChunkManager<T>();
        }
    }
}