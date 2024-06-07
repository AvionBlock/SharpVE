using SharpVE.Interfaces;

namespace SharpVE.Chunks.Layers
{
    public class SingleLayeredChunk<T> : ILayeredChunk<T>
    {
        public T BlockState { get; private set; }

        public SingleLayeredChunk(SubChunk<T> subChunk, T blockState)
        {
            BlockState = blockState;
            if(!subChunk.BlockPalette.Has(blockState))
            {
                subChunk.BlockPalette.Add(blockState);
            }
        }

        public T GetBlockState(SubChunk<T> subChunk, int localX, int localZ)
        {
            throw new System.NotImplementedException();
        }

        public int GetBlockStateID(SubChunk<T> subChunk, int localX, int localZ)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlockState(SubChunk<T> subChunk, T blockState, int localX, int localY, int localZ)
        {
            throw new System.NotImplementedException();
        }

        public void Set(SubChunk<T> subChunk, T blockState, int localY)
        {
            BlockState = blockState;
            if(!subChunk.BlockPalette.Has(blockState))
            {
                subChunk.BlockPalette.Add(blockState);
            }
        }
    }
}