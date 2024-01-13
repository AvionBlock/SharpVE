using SharpVE.Core.Blocks;
using SharpVE.Core.World.Chunks.Layers;
using System.Collections.Generic;

namespace SharpVE.Core.World.Chunks
{
    public class ChunkData : IChunkData
    {
        private Dictionary<ushort, BlockState> BlockStates { get; set; }
        private ILayeredChunkData[] Layers { get; set; }

        public ChunkData()
        {
            BlockStates = new Dictionary<ushort, BlockState>();
            Layers = new ILayeredChunkData[Chunk.CHUNK_HEIGHT];
        }
    }
}
