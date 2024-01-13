using SharpVE.Core.Blocks;
using Silk.NET.Maths;

namespace SharpVE.Core.World.Chunks
{
    public interface IChunkData
    {
        public void GetBlock(Vector3D<int> localPosition);
        public void SetBlock(Vector3D<int> localPosition, BlockState blockState);
    }
}
