using System;
using SharpVE.Chunks;

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
        /// <param name="defaultSize"> The default size to allocate. </param>
        public BlockPalette(int defaultSize)
        {
            BlockStates = new T[defaultSize];
        }

        /// <summary>
        /// Adds a block state to the block palette. (Does not overwrite same blockstates)
        /// </summary>
        /// <param name="blockState"> The blockstate to add. </param>
        public void Add(T blockState)
        {
            if (Size == BlockStates.Length)
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
        /// Gets a blockstate from an ID.
        /// </summary>
        /// <param name="blockId"> The block ID to get the blockstate. </param>
        public T Get(int blockId)
        {
            return BlockStates[blockId];
        }

        /// <summary>
        /// Checks if the blockstate exists in the palette.
        /// </summary>
        /// <param name="subChunk"> The subchunk to determine ID. </param>
        /// <param name="blockState"> The blockstate to get the ID for. </param>
        public bool Has(SubChunk<T> subChunk, T blockState)
        {
            return subChunk.GetBlockStateID(blockState) != -1;
        }

        /// <summary>
        /// Copies the values from a block palette and set's it internally.
        /// </summary>
        /// <param name="blockPalette"> The <see cref="BlockPalette"/> to copy from. </param>
        public void CopyFromPalette(BlockPalette<T> blockPalette)
        {
            Size = blockPalette.Size;
            BlockStates = blockPalette.BlockStates;
        }
    }
}
