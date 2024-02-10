using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks.Layers
{
    public class SingleBlockLayerData : ILayerData
    {
        private SubChunkData SubChunkData;
        private ushort BlockId;

        public SingleBlockLayerData(SubChunkData SubChunkData, ushort BlockId = 0)
        {
            this.SubChunkData = SubChunkData;
            this.BlockId = BlockId;
        }

        public ushort GetBlock(int localX, int localZ)
        {
            if (!CoordinateIsValid(localX, localZ)) return 0;

            return BlockId;
        }

        public ushort GetBlock(Vector2D<int> localPos)
        {
            return BlockId;
        }

        public void SetBlock(int localX, int localZ, ushort blockId)
        {
            if (!CoordinateIsValid(localX, localZ)) return;

            BlockId = blockId;
        }

        public void SetBlock(Vector2D<int> localPos, ushort blockId)
        {
            BlockId = blockId;
        }

        private bool CoordinateIsValid(int localX, int localZ)
        {
            if (localX < 0 || localZ < 0 || localX >= ChunkColumn.CHUNK_WIDTH || localZ >= ChunkColumn.CHUNK_DEPTH) return false;
            return true;
        }
    }
}
