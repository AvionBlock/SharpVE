using SharpVE.Core.Blocks;
using SharpVE.Core.World.Chunks.Layers;
using Silk.NET.Maths;
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

        public void GetBlock(Vector3D<int> localPosition)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlock(Vector3D<int> localPosition, BlockState blockState)
        {
            throw new System.NotImplementedException();
        }
    }
}
