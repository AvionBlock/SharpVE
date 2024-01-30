using SharpVE.World.Chunks;
using System.Collections.Generic;

namespace SharpVE.World
{
    public class World
    {
        public List<ChunkColumn> Chunks { get; set; } = new List<ChunkColumn>();
    }
}
