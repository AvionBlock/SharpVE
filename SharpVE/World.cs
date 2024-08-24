using SharpVE.Chunks;
using SharpVE.Data;
using SharpVE.Interfaces;
using System.Collections.Generic;

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