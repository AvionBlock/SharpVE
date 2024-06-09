using SharpVE.Interfaces;

namespace SharpVE.Chunks.Layers
{
    /// <summary>
    /// A layered chunk
    /// </summary>
    public class ShortLayeredChunk<T> : ILayeredChunk<T> where T : class
    {
        /// <summary>
        /// The list of stored blocks.
        /// </summary>
        public short[] BlockIDs { get; private set; }

        /// <summary>
        /// Creates a new <see cref="ShortLayeredChunk{T}"/> that is the size of a <see cref="short"/> for each block ID from the specified data.
        /// </summary>
        public ShortLayeredChunk(short[] data)
        {
            BlockIDs = data;
        }

        /// <summary>
        /// Creates a new <see cref="ShortLayeredChunk{T}"/> that is the size of a <see cref="short"/> for each block ID.
        /// </summary>
        /// <param name="subChunk">The subchunk to set the blockState to.</param>
        /// <param name="blockState">The default blockstate to set.</param>
        /// <param name="localY">The local Y layer of this layer to set in the subChunk.</param>
        public ShortLayeredChunk(SubChunk<T> subChunk, T blockState, int localY)
        {
            BlockIDs = new short[ISubChunk<T>.SIZE * ISubChunk<T>.SIZE];
            for (var x = 0; x < ISubChunk<T>.SIZE; x++)
            {
                for (var z = 0; z < ISubChunk<T>.SIZE; z++)
                {
                    SetBlockState(subChunk, blockState, x, localY, z);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="ShortLayeredChunk{T}"/> that is the size of a <see cref="short"/> for each block ID from a <see cref="ByteLayeredChunk{T}"/>.
        /// </summary>
        /// <param name="subChunk">The subchunk to set the blockStates to.</param>
        /// <param name="byteLayeredChunk">The layer to convert from.</param>
        /// <param name="localY">The local Y layer of this layer to set in the subChunk.</param>
        public ShortLayeredChunk(SubChunk<T> subChunk, ByteLayeredChunk<T> byteLayeredChunk, int localY)
        {
            BlockIDs = new short[ISubChunk<T>.SIZE * ISubChunk<T>.SIZE];
            for (int x = 0; x < ISubChunk<T>.SIZE; x++)
            {
                for (int z = 0; z < ISubChunk<T>.SIZE; z++)
                {
                    SetBlockState(subChunk, byteLayeredChunk.GetBlockState(subChunk, x, z), x, localY, z);
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="BlockState"/> in the layer.
        /// </summary>
        /// <param name="subChunk">The subchunk to get the blockstate value from.</param>
        /// <param name="localX">The localX of the layer.</param>
        /// <param name="localZ">The localZ of the layer.</param>
        /// <returns></returns>
        public T GetBlockState(SubChunk<T> subChunk, int localX, int localZ)
        {
            return subChunk.BlockPalette.Get(GetBlockStateID(subChunk, localX, localZ));
        }

        /// <summary>
        /// Gets an <see cref="int"/> block ID in the layer.
        /// </summary>
        /// <param name="subChunk">The subchunk to get the block ID value from.</param>
        /// <param name="localX">The localX of the layer.</param>
        /// <param name="localZ">The localZ of the layer.</param>
        /// <returns></returns>
        public int GetBlockStateID(SubChunk<T> subChunk, int localX, int localZ)
        {
            var idx = localX + (localZ * ISubChunk<T>.SIZE);
            var blockId = BlockIDs[idx];

            return blockId;
        }

        /// <summary>
        /// Sets a <see cref="BlockState"/> in the layer.
        /// </summary>
        /// <param name="subChunk">The subchunk to set the blockstate value to.</param>
        /// <param name="blockState">The <see cref="BlockState"/> to set.</param>
        /// <param name="localX">The localX of the layer.</param>
        /// <param name="localY">The localY of the layer.</param>
        /// <param name="localZ">The localZ of the layer.</param>
        public void SetBlockState(SubChunk<T> subChunk, T blockState, int localX, int localY, int localZ)
        {
            if (!subChunk.BlockPalette.Has(subChunk, blockState))
            {
                subChunk.BlockPalette.Add(blockState);
            }

            var fullId = subChunk.GetBlockStateID(blockState);
            if (fullId > ISubChunk<T>.NUM_OF_BLOCKS - 1)
            {
                subChunk.CleanPalette();
                subChunk.SetBlockState(blockState, localX, localY, localZ);
                return;
            }

            T oldBlock = GetBlockState(subChunk, localX, localZ);
            if (oldBlock != blockState)
            {
                var idx = localX + (localZ * ISubChunk<T>.SIZE);
                BlockIDs[idx] = (short)fullId;
            }
        }
    }
}
