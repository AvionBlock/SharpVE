using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;
using System;

namespace SharpVE.World.Chunks
{
    public class SubChunk
    {
        public readonly sbyte YLevel;

        private ChunkColumn ChunkColumn;
        private ISubChunkData Data;

        public SubChunk(ChunkColumn ChunkColumn, sbyte yLevel)
        {
            this.ChunkColumn = ChunkColumn;
            Data = new SingleBlockSubChunkData(this);
            YLevel = yLevel;
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            throw new NotImplementedException();
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            SetBlock(localPos.X, localPos.Y, localPos.Z, block);
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            throw new NotImplementedException();
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y, localPos.Z);
        }
    }
}
