using SharpVE.Core.Blocks;
using Silk.NET.Maths;

namespace SharpVE.Core.Interfaces.Chunks
{
    public interface ISubChunkData
    {
        BlockState? GetBlock(int localX, int localY, int localZ);
        BlockState? GetBlock(Vector3D<int> localPos);
        void SetBlock(int localX, int localY, int localZ, BlockState block);
        void SetBlock(Vector3D<int> localPos, BlockState block);
    }
}
