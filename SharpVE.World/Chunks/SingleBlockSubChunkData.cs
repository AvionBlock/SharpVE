using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks
{
    public class SingleBlockSubChunkData : ISubChunkData
    {
        private SubChunk SubChunk; //May use this later but for now, Not really needed.
        private ushort BlockId;

        public SingleBlockSubChunkData(SubChunk SubChunk, ushort BlockId = 0)
        {
            this.SubChunk = SubChunk;
            this.BlockId = BlockId;
        }

        public ushort GetBlock(int localX, int localY, int localZ)
        {
            if(!CoordinateIsValid(localX, localY, localZ)) return 0;
            return BlockId;
        }

        public ushort GetBlock(Vector3D<int> localPos)
        {
            return BlockId;
        }

        public void SetBlock(int localX, int localY, int localZ, ushort blockId)
        {
            if (!CoordinateIsValid(localX, localY, localZ)) return;
            BlockId = blockId;
        }

        public void SetBlock(Vector3D<int> localPos, ushort blockId)
        {
            BlockId = blockId;
        }

        private bool CoordinateIsValid(int localX, int localY, int localZ)
        {
            if (localX < 0 || localY < 0 || localZ < 0 || localX >= ChunkColumn.CHUNK_WIDTH || localY >= ChunkColumn.CHUNK_HEIGHT || localZ >= ChunkColumn.CHUNK_DEPTH) return false;
            return true;
        }
    }
}
