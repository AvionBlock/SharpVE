using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;
using System;
using System.Collections.Generic;

namespace SharpVE.World.Chunks
{
    public class SubChunk
    {
        public readonly sbyte YLevel;

        private readonly Dictionary<ushort, BlockState> BlockStates;
        private ChunkColumn ChunkColumn;
        private ISubChunkData Data;

        public SubChunk(ChunkColumn ChunkColumn, sbyte yLevel)
        {
            this.ChunkColumn = ChunkColumn;
            BlockStates = new Dictionary<ushort, BlockState>();
            Data = new SingleBlockSubChunkData(this);
            YLevel = yLevel;
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            if (Data is SingleBlockSubChunkData)
            {
                BlockStates.TryGetValue(Data.GetBlock(0, 0, 0), out var blockState);
            }
            else if(Data is SubChunkData)
            {

            }
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            SetBlock(localPos.X, localPos.Y, localPos.Z, block);
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            BlockStates.TryGetValue(Data.GetBlock(0, 0, 0), out var blockState);
            return blockState;
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y, localPos.Z);
        }
    }
}
