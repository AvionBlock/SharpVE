using SharpVE.Chunks;

namespace SharpVE.Interfaces
{
    /// <summary>
    /// A interface for a layered chunk.
    /// </summary>
    public interface ILayeredChunk<T> where T : class //BlockStates must be an object.
    {
        /// <summary>
        /// Gets a <see cref="BlockState"/> in the layer.
        /// </summary>
        /// <param name="subChunk">The subchunk to get the blockstate value from.</param>
        /// <param name="localX">The localX of the layer.</param>
        /// <param name="localZ">The localZ of the layer.</param>
        /// <returns>The block state.</returns>
        T GetBlockState(SubChunk<T> subChunk, int localX, int localZ);

        /// <summary>
        /// Gets an <see cref="int"/> block ID in the layer.
        /// </summary>
        /// <param name="subChunk">The subchunk to get the block ID value from.</param>
        /// <param name="localX">The localX of the layer.</param>
        /// <param name="localZ">The localZ of the layer.</param>
        /// <returns>The block ID for the block palette.</returns>
        int GetBlockStateID(SubChunk<T> subChunk, int localX, int localZ);

        /// <summary>
        /// Sets a <see cref="BlockState"/> in the layer.
        /// </summary>
        /// <param name="subChunk">The subchunk to set the blockstate value to.</param>
        /// <param name="blockState">The <see cref="BlockState"/> to set.</param>
        /// <param name="localX">The localX of the layer.</param>
        /// <param name="localY">The localY of the layer.</param>
        /// <param name="localZ">The localZ of the layer.</param>
        void SetBlockState(SubChunk<T> subChunk, T blockState, int localX, int localY, int localZ);
    }
}