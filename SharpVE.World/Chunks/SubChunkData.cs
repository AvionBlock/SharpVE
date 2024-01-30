using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks
{
    public class SubChunkData : ISubChunkData
    {
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
