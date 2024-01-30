using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;
using System;

namespace SharpVE.World.Chunks
{
    public class SingleBlockSubChunkData : ISubChunkData
    {
        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            throw new NotImplementedException();
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            throw new NotImplementedException();
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            throw new NotImplementedException();
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            throw new NotImplementedException();
        }
    }
}
