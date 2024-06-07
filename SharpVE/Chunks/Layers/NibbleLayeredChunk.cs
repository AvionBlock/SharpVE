using SharpVE.Interfaces;

namespace SharpVE.Chunks.Layers
{
    /// <summary>
    /// A layered chunk
    /// </summary>
    public class NibbleLayeredChunk<T> : ILayeredChunk<T>
    {
        /// <summary>
        /// The list of stored blocks.
        /// </summary>
        public byte[] BlockIDs { get; private set; }

        /// <summary>
        /// Creates a new <see cref="NibbleLayeredChunk{T}"/> that is the size of a <see cref="byte"/> for each block ID from the specified data.
        /// </summary>
        public NibbleLayeredChunk(byte[] data)
        {
            BlockIDs = data;
        }

        /// <summary>
        /// Creates a new <see cref="NibbleLayeredChunk{T}"/> that is the size of a <see cref="byte"/> for each block ID.
        /// </summary>
        /// <param name="subChunk">The subchunk to set the blockState to.</param>
        /// <param name="blockState">The default blockstate to set.</param>
        /// <param name="localY">The local Y layer of this layer to set in the subChunk.</param>
        public NibbleLayeredChunk(SubChunk<T> subChunk, T blockState, int localY)
        {
            BlockIDs = new byte[SubChunk<T>.SIZE * SubChunk<T>.SIZE / 2];
            var paletteId = subChunk.GetBlockStateID(blockState);
            if (paletteId != 0)
            {
                for (var x = 0; x < SubChunk<T>.SIZE; x++)
                {
                    for (var z = 0; z < SubChunk<T>.SIZE; z++)
                    {
                        SetBlockState(subChunk, blockState, x, localY, z);
                    }
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
        public int GetBlockStateID(SubChunk<T>? subChunk, int localX, int localZ) //Special Case
        {
            var idx = (localX + (localZ * SubChunk<T>.SIZE)) / 2;
            var blockId = (int)BlockIDs[idx];

            var mod2 = localX % 2;
            blockId = (mod2 * ((blockId & 0xF0) >> 4)) + ((1 - mod2) * blockId % 0x0F);

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
            var paletteId = subChunk.GetBlockStateID(blockState);
            if (paletteId == -1)
            {
                paletteId = subChunk.BlockPalette.BlockStates.Length;
                subChunk.BlockPalette.Add(blockState);
            }
            if (paletteId > 15)
            {
                var layer = new ByteLayeredChunk<T>(subChunk, blockState, localY);
                layer.SetBlockState(subChunk, blockState, localX, localY, localZ);
                subChunk.SetLayer(layer, localY);
                return;
            }

            var oldBlockId = GetBlockStateID(null, localX, localZ);
            if (oldBlockId != paletteId)
            {
                var idx = (localX + (localZ * SubChunk<T>.SIZE)) / 2;
                var block = BlockIDs[idx];
                if (localX % 2 == 0)
                {
                    BlockIDs[idx] = (byte)((block & 0xF0) | paletteId);
                }
                else
                {
                    BlockIDs[idx] = (byte)((block & 0x0F) | (paletteId << 4));
                }
            }
        }
    }
}