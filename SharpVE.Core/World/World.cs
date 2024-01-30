using SharpVE.Core.World.Chunks;
using System.Collections.Generic;

namespace SharpVE.Core.World
{
    public class World
    {
        public List<ChunkColumn> Chunks { get; set; } = new List<ChunkColumn>();
    }
}
