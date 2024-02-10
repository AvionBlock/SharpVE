using SharpVE.Core.Blocks;
using SharpVE.Core.Interfaces.Chunks;
using SharpVE.World.Storage;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks
{
    public class SubChunk
    {
        public readonly sbyte YLevel;

        private readonly BlockStorage BlockStates;
        private ChunkColumn ChunkColumn;
        private ISubChunkData Data;

        public SubChunk(ChunkColumn ChunkColumn, sbyte yLevel)
        {
            this.ChunkColumn = ChunkColumn;
            BlockStates = new BlockStorage();
            Data = new SingleBlockSubChunkData(this);
            YLevel = yLevel;

            BlockStates.AddBlockState(ChunkColumn.World.Blocks.DefaultBlock.GetBlockState());
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            if (Data is SingleBlockSubChunkData)
            {
                var blockState = BlockStates.TryGetBlockState(Data.GetBlock(0, 0, 0));
                if (blockState?.Equals(block) ?? false) return;

                Data = new SubChunkData(this);
                ushort blockId;
                try
                {
                    blockId = BlockStates.AddBlockState(block);
                }
                catch
                {
                    blockId = BlockStates.GetBlockStateId(block);
                }
                Data.SetBlock(localX, localY, localZ, blockId);
            }
            else if(Data is SubChunkData)
            {
                ushort blockId;
                try
                {
                    blockId = BlockStates.AddBlockState(block);
                }
                catch
                {
                    blockId = BlockStates.GetBlockStateId(block);
                }
                Data.SetBlock(localX, localY, localZ, blockId);

                //Do checks for converting to single block later.
            }
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            SetBlock(localPos.X, localPos.Y, localPos.Z, block);
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            return BlockStates.TryGetBlockState(Data.GetBlock(localX, localY, localZ));
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y, localPos.Z);
        }
    }
}
