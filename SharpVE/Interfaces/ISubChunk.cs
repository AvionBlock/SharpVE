using System;

namespace SharpVE.Interfaces
{
    public interface ISubChunk<T>
    {
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
    }
}