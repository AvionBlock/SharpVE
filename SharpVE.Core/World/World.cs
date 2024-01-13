using SharpVE.Core.World.Chunk;
using System.Collections.Generic;

namespace SharpVE.Core.World
{
    public class World
    {
        public List<IChunkData> Chunks { get; set; } = new List<IChunkData>();
    }
}
