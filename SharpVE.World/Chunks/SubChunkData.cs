using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;
using System.Collections.Generic;

namespace SharpVE.World.Chunks
{
    public class SubChunkData : ISubChunkData
    {
        private Dictionary<ushort, BlockState> BlockStates;
        private ILayerData?[] Data;

        public SubChunkData()
        {
            BlockStates = new Dictionary<ushort, BlockState>();
            Data = new ILayerData[ChunkColumn.CHUNK_HEIGHT];
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            throw new System.NotImplementedException();
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            throw new System.NotImplementedException();
        }
    }
}
