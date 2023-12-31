﻿using SharpVE.Interfaces;
using SharpVE.Worlds.Chunks;
using SharpVE.Blocks;
using Silk.NET.Maths;

namespace SharpVE.WorldSpace.Chunk.Layer
{
    public class SingleBlockChunkLayer : ILayerData
    {
        private ushort BlockId;
        public SubChunk Chunk { get; }
        public byte YLevel { get; }

        public SingleBlockChunkLayer(SubChunk chunk, byte yLevel, ushort blockId)
        {
            Chunk = chunk;
            YLevel = yLevel;
            BlockId = blockId;
        }

        public BlockState? GetBlock(Vector2D<int> localPosition)
        {
            if (localPosition.X >= ChunkColumn.SIZE || localPosition.Y >= ChunkColumn.SIZE ||
                localPosition.X < 0 || localPosition.Y < 0) return null;

            Chunk.BlockStates.TryGetValue(BlockId, out var blockState);
            return blockState;
        }

        public void SetBlock(Vector2D<int> localPosition, BlockState state)
        {
            throw new Exception("Cannot set block on a single block chunk layer!");
        }
    }
}
