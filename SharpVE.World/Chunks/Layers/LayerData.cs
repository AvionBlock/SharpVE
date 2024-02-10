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
            if(!CoordinateIsValid(localX, localZ)) return 0;

            var id = localX + localZ * ChunkColumn.CHUNK_DEPTH;
            return Data[id]; 
        }

        public ushort GetBlock(Vector2D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y);
        }

        public void SetBlock(int localX, int localZ, ushort blockId)
        {
            if (!CoordinateIsValid(localX, localZ)) return;

            var id = localX * ChunkColumn.CHUNK_WIDTH + localZ;
            Data[id] = blockId;
        }

        public void SetBlock(Vector2D<int> localPos, ushort blockId)
        {
            SetBlock(localPos.X, localPos.Y, blockId);
        }

        private bool CoordinateIsValid(int localX, int localZ)
        {
            if (localX < 0 || localZ < 0 || localX >= ChunkColumn.CHUNK_WIDTH || localZ >= ChunkColumn.CHUNK_DEPTH) return false;
            return true;
        }
    }
}
