using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;

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
            var id = localX + localZ * ChunkColumn.CHUNK_DEPTH;
            return Data[id]; 
        }

        public ushort GetBlock(Vector2D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y);
        }

        public void SetBlock(int localX, int localZ, ushort blockId)
        {
            var id = localX * ChunkColumn.CHUNK_WIDTH + localZ;
            Data[id] = blockId;
        }

        public void SetBlock(Vector2D<int> localPos, ushort blockId)
        {
            SetBlock(localPos.X, localPos.Y, blockId);
        }
    }
}
