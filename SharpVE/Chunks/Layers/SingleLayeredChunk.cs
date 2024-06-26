using SharpVE.Interfaces;

namespace SharpVE.Chunks.Layers
{
    /// <summary>
    /// A single block layered chunk
    /// </summary>
    public class SingleLayeredChunk<T> : ILayeredChunk<T> where T : class
    {
        public T BlockState { get; private set; }

        public SingleLayeredChunk(SubChunk<T> subChunk, T blockState)
        {
            BlockState = blockState;
            if(!subChunk.BlockPalette.Has(subChunk, blockState))
            {
                subChunk.BlockPalette.Add(blockState);
            }
        }

        public T GetBlockState(SubChunk<T> subChunk, int localX, int localZ)
        {
            return BlockState;
        }

        public int GetBlockStateID(SubChunk<T> subChunk, int localX, int localZ)
        {
            return subChunk.GetBlockStateID(BlockState);
        }

        public void SetBlockState(SubChunk<T> subChunk, T blockState, int localX, int localY, int localZ)
        {
            if(blockState == BlockState)
            {
                return;
            }

            var layer = new NibbleLayeredChunk<T>(subChunk, blockState, localY);
            subChunk.SetLayer(layer, localY);
            layer.SetBlockState(subChunk, blockState, localX, localY, localZ);
        }

        public virtual void Fill(SubChunk<T> subChunk, T blockState, int localY)
        {
            BlockState = blockState;
            if(!subChunk.BlockPalette.Has(subChunk, blockState))
            {
                subChunk.BlockPalette.Add(blockState);
            }
        }
    }
}