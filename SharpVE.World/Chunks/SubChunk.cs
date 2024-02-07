using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using Silk.NET.Maths;
using System.Collections.Generic;
using System.Linq;

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

        #region BlockSetters
        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            if (Data is SingleBlockSubChunkData)
            {
                BlockStates.TryGetValue(Data.GetBlock(0, 0, 0), out var blockState);
                if (blockState?.Equals(block) ?? false) return;

                Data = new SubChunkData(this);
                Data.SetBlock(localX, localY, localZ, GetOrAddBlock(block));
            }
            else if(Data is SubChunkData)
            {
                Data.SetBlock(localX, localY, localZ, GetOrAddBlock(block));
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
        #endregion

        #region Private Methods
        private ushort GetLowestAvailableKey()
        {
            for(ushort i = 0; i < BlockStates.Count; i++)
            {
                if (!BlockStates.ContainsKey(i)) return i;
            }
            return 0;
        }

        private ushort GetOrAddBlock(BlockState block)
        {
            if (BlockStates.ContainsValue(block))
            {
                var blockInstance = BlockStates.FirstOrDefault(x => x.Value.Equals(block));
                if (blockInstance.Value != null) return blockInstance.Key;
            }

            var blockId = GetLowestAvailableKey();
            BlockStates.Add(blockId, block);
            return blockId;
        }
        #endregion
    }
}
