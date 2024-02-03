using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks
{
    public class SingleBlockSubChunkData : ISubChunkData
    {
        private SubChunk SubChunk;
        private BlockState? BlockState;

        public SingleBlockSubChunkData(SubChunk SubChunk, BlockState? BlockState = null)
        {
            this.SubChunk = SubChunk;
            this.BlockState = BlockState;
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            return BlockState;
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            return BlockState;
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            BlockState = block;
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            BlockState = block;
        }
    }
}
