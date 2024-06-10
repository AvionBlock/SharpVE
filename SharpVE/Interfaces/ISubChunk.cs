using System;

namespace SharpVE.Interfaces
{
    public interface ISubChunk<T> where T : class //BlockStates must be an object.
    {
        /// <summary>
        /// The size of the subchunk on the X, Y and Z axis's.
        /// </summary>
        static ushort SIZE = 16; //Default.

        /// <summary>
        /// The total number of blocks inside the sub chunk.
        /// </summary>
        static ushort NUM_OF_BLOCKS = (ushort)(SIZE ^ 3);

        /// <summary>
        /// Defines whether the subchunk has been updated. Useful for remeshing.
        /// </summary>
        bool IsDirty { get; set; }

        /// <summary>
        /// Get's a blockstate on the localX, localY and localZ coordinates.
        /// </summary>
        /// <param name="localX"> The local X coordinate </param>
        /// <param name="localY"> The local Y coordinate </param>
        /// <param name="localZ"> The local Z coordinate </param>
        T GetBlockState(int localX, int localY, int localZ);

        /// <summary>
        /// Get's a blockstate ID on the localX, localY and localZ coordinates.
        /// </summary>
        /// <param name="localX"> The local X coordinate </param>
        /// <param name="localY"> The local Y coordinate </param>
        /// <param name="localZ"> The local Z coordinate </param>
        int GetBlockStateID(int localX, int localY, int localZ);

        /// <summary>
        /// Get's a blockstate ID from a blockState instance.
        /// </summary>
        /// <param name="blockState"> The blockstate instance </param>
        int GetBlockStateID(T blockState);

        /// <summary>
        /// Set's a blockstate
        /// </summary>
        /// <param name="blockState"> The blockstate to set. </param>
        /// <param name="localX"> the local X coordinate to set the blockstate to. </param> 
        /// <param name="localY"> the local Y coordinate to set the blockstate to. </param> 
        /// <param name="localZ"> the local Z coordinate to set the blockstate to. </param> 
        ISubChunk<T> SetBlockState(T blockState, int localX, int localY, int localZ);

        /// <summary>
        /// Fills the subchunk with a blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to fill the subchunk with. </param>
        ISubChunk<T> Fill(T blockState);

        /// <summary>
        /// Fills a layer with a blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to fill the layer with. </param>
        /// <param name="localY"> The local Y layer to set. </param>
        ISubChunk<T> FillLayer(T blockState, int localY);

        /// <summary>
        /// Check's if the entire subchunk matches the predicate.
        /// </summary>
        /// <param name="predicate"> The predicate to check against. </param>
        bool IsAll(Predicate<T> predicate);

        /// <summary>
        /// Check's if the entire subchunk matches the blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to check against. </param>
        bool IsAll(T blockState);

        /// <summary>
        /// Get's the size of the block palette.
        /// </summary>
        /// <returns>The size of all the unique blocks.</returns>
        int GetBlockPaletteSize();
    }
}