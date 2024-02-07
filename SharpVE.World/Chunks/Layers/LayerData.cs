using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;
using System;

namespace SharpVE.World.Chunks.Layers
{
    public class LayerData : ILayerData
    {
        private SubChunkData SubChunkData;
        private ushort[] Data;
        
        public LayerData(SubChunkData SubChunkData)
        {
            this.SubChunkData = SubChunkData;
            Data = new ushort[ChunkColumn.CHUNK_WIDTH * ChunkColumn.CHUNK_DEPTH];
        }

        public ushort GetBlock(int localX, int localZ)
        {
            throw new NotImplementedException();
        }

        public ushort GetBlock(Vector2D<int> localPos)
        {
            throw new NotImplementedException();
        }

        public void SetBlock(int localX, int localZ, ushort blockId)
        {
            throw new NotImplementedException();
        }

        public void SetBlock(Vector2D<int> localPos, ushort blockId)
        {
            throw new NotImplementedException();
        }
    }
}
