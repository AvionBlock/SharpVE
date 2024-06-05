using SharpVE.Data;

namespace SharpVE.Chunks
{
    /// <summary>
    /// A subchunk.
    /// </summary>
    public class SubChunk<T>
    {
        public static ushort SIZE = 16; //Default.
        public static ushort NUM_OF_BLOCKS = (ushort)(SIZE ^ 3);

        //Layers
        public BlockPalette<T> BlockPalette { get; private set; }
        public object[] Layers { get; private set; } //Will Change Later To Interface.

        public T GetBlockState(int localX, int localY, int localZ)
        {
            return Layers[localY].GetBlockState(this, localX, localZ);
        }

        public int GetBlockStateID(int localX, int localY, int localZ)
        {
            return Layers[localY].GetBlockStateID(this, localX, localZ);
        }

        public int GetBlockStateID(T blockState)
        {
            int paletteSize = BlockPalette.Size;
            for (int i = 0; i < paletteSize; i++)
            {
                if (BlockPalette.BlockStates[i] == blockState)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}