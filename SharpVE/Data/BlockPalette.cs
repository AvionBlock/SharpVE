using System;

namespace SharpVE.Data
{
    /// <summary>
    /// Holds a list of block states.
    /// </summary>
    public class BlockPalette<T>
    {
        /// <summary>
        /// The list of blockstates.
        /// </summary>
        public T[] BlockStates { get; private set; }

        /// <summary>
        /// The size of the palette.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Creates a new block palette.
        /// </summary>
        public BlockPalette(int defaultSize)
        {
            BlockStates = new T[defaultSize];
        }

        /// <summary>
        /// Adds a block state to the block palette. (Does not overwrite same blockstates)
        /// </summary>
        public void Add(T blockState)
        {
            if(Size == BlockStates.Length)
            {
                var newSize = (int)(Size * 1.75f);
                newSize = Math.Max(newSize, Size + 1);
                var newBlockStates = new T[newSize];
                Buffer.BlockCopy(BlockStates, 0, newBlockStates, 0, BlockStates.Length);
            }
            BlockStates[Size] = blockState;
            Size++;
        }

        /// <summary>
        /// Gets a blockstate from an Id.
        /// </summary>
        public T Get(int blockId)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Checks if the blockstate exists in the palette.
        /// </summary>
        public bool Has(T blockState)
        {
            return false;
        }

        /// <summary>
        /// Clears the block palette.
        /// </summary>
        public void Clean()
        { }
    }
}
