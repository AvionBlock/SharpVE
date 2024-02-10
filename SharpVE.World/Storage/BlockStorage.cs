using SharpVE.Core.Blocks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SharpVE.World.Storage
{
    public class BlockStorage
    {
        public readonly Dictionary<ushort, BlockState> BlockStates;

        public BlockStorage()
        {
            BlockStates = new Dictionary<ushort, BlockState>();
        }

        public ushort AddBlockState(BlockState block)
        {
            if (BlockStates.ContainsValue(block)) throw new Exception("Blockstate already exists!");

            var blockId = BlockStates.Keys.Min();
            BlockStates.Add(blockId, block);
            return blockId;
        }

        public ushort GetBlockStateId(BlockState block)
        {
            var blockState = BlockStates.FirstOrDefault(x => x.Equals(block));
            if (blockState.Value == null) throw new Exception("Blockstate does not exist!");
            return blockState.Key;
        }

        public BlockState TryGetBlockState(ushort blockId)
        {
            BlockStates.TryGetValue(blockId, out var state);
            return state;
        }

        public void RemoveBlockState(ushort blockId)
        {
            BlockStates.Remove(blockId);
        }
    }
}
