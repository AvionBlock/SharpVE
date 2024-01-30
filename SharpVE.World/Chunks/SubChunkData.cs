using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;
using System.Collections.Generic;

namespace SharpVE.World.Chunks
{
    public class SubChunkData : ISubChunkData
    {
        private ChunkColumn ChunkColumn;
        private Dictionary<ushort, BlockState> BlockStates;
        private ILayerData?[] Data;

        public SubChunkData(ChunkColumn ChunkColumn)
        {
            this.ChunkColumn = ChunkColumn;
            BlockStates = new Dictionary<ushort, BlockState>();
            Data = new ILayerData[ChunkColumn.CHUNK_HEIGHT];
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            var layer = Data[localY];
            if(layer != null)
            {
                var blockId = layer.GetBlock(localX, localZ);
                BlockStates.TryGetValue(blockId, out var blockState);
                return blockState;
            }
            return null;
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y, localPos.Z);
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
