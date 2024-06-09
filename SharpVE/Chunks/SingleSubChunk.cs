using SharpVE.Interfaces;
using System;

namespace SharpVE.Chunks
{
    /// <summary>
    /// A single block subchunk.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleSubChunk<T> : ISubChunk<T> where T : class
    {
        /// <summary>
        /// The set blockstate.
        /// </summary>
        public T BlockState = default!;

        /// <summary>
        /// Creates a new single block <see cref="SingleSubChunk{T}"/>.
        /// </summary>
        public SingleSubChunk() { }

        /// <summary>
        /// Creates a new single block <see cref="SingleSubChunk{T}"/>.
        /// </summary>
        /// <param name="blockState">The blockstate to set.</param>
        public SingleSubChunk(T blockState)
        {
            BlockState = blockState;
        }

        /// <summary>
        /// Get's a blockstate on the localX, localY and localZ coordinates.
        /// </summary>
        /// <param name="localX"> The local X coordinate </param>
        /// <param name="localY"> The local Y coordinate </param>
        /// <param name="localZ"> The local Z coordinate </param>
        public T GetBlockState(int localX, int localY, int localZ)
        {
            return BlockState;
        }

        /// <summary>
        /// Get's a blockstate ID on the localX, localY and localZ coordinates.
        /// </summary>
        /// <param name="localX"> The local X coordinate </param>
        /// <param name="localY"> The local Y coordinate </param>
        /// <param name="localZ"> The local Z coordinate </param>
        public int GetBlockStateID(int localX, int localY, int localZ)
        {
            return 0;
        }

        /// <summary>
        /// Get's a blockstate ID from a blockState instance.
        /// </summary>
        /// <param name="blockState"> The blockstate instance </param>
        public int GetBlockStateID(T blockState)
        {
            return blockState == BlockState? 0 : -1;
        }

        /// <summary>
        /// Set's a blockstate
        /// </summary>
        /// <param name="blockState"> The blockstate to set. </param>
        /// <param name="localX"> the local X coordinate to set the blockstate to. </param> 
        /// <param name="localY"> the local Y coordinate to set the blockstate to. </param> 
        /// <param name="localZ"> the local Z coordinate to set the blockstate to. </param>
        public ISubChunk<T> SetBlockState(T blockState, int localX, int localY, int localZ)
        {
            if (blockState != BlockState)
            {
                var newSubChunk = new SubChunk<T>(BlockState);
                return newSubChunk.SetBlockState(blockState, localX, localY, localZ);
            }
            return this;
        }

        /// <summary>
        /// Fills the subchunk with a blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to fill the subchunk with. </param>
        public ISubChunk<T> Fill(T blockState)
        {
            BlockState = blockState;
            return this;
        }

        /// <summary>
        /// Fills a layer with a blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to fill the layer with. </param>
        /// <param name="localY"> The local Y layer to set. </param>
        public ISubChunk<T> FillLayer(T blockState, int localY)
        {
            if(blockState != BlockState)
            {
                var newSubChunk = new SubChunk<T>(BlockState);
                return newSubChunk.FillLayer(blockState, localY);
            }
            return this;
        }

        /// <summary>
        /// Check's if the entire subchunk matches the predicate.
        /// </summary>
        /// <param name="predicate"> The predicate to check against. </param>
        public bool IsAll(Predicate<T> predicate)
        {
            return predicate.Invoke(BlockState);
        }

        /// <summary>
        /// Check's if the entire subchunk matches the blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to check against. </param>
        public bool IsAll(T blockState)
        {
            return blockState == BlockState;
        }

        /// <summary>
        /// Get's the size of the block palette.
        /// </summary>
        /// <returns>The size of all the unique blocks.</returns>
        public int GetBlockPaletteSize()
        {
            return 1;
        }
    }
}
