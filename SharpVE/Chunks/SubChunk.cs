using System;
using System.Collections.Generic;
using SharpVE.Chunks.Layers;
using SharpVE.Data;
using SharpVE.Interfaces;

namespace SharpVE.Chunks
{
    /// <summary>
    /// A subchunk.
    /// </summary>
    public class SubChunk<T> : ISubChunk<T>
    {
        /// <summary>
        /// The size of the subchunk in X, Y and Z axis's.
        /// </summary>
        public static ushort SIZE = 16; //Default.

        /// <summary>
        /// The total number of blocks inside the sub chunk.
        /// </summary>
        public static ushort NUM_OF_BLOCKS = (ushort)(SIZE ^ 3);

        /// <summary>
        /// The block palette inside the subchunk.
        /// </summary>
        public BlockPalette<T> BlockPalette { get; private set; }

        /// <summary>
        /// The layers that make up the subchunk. Each layer contains block data.
        /// </summary>
        public ILayeredChunk<T>[] Layers { get; private set; } = new ILayeredChunk<T>[SIZE];


        /// <summary>
        /// Creates a new subchunk with a specified default palette size.
        /// </summary>
        /// <param name="defaultPaletteSize"> The size of the block palette on creation. </param>
        public SubChunk(int defaultPaletteSize)
        {
            BlockPalette = new BlockPalette<T>(defaultPaletteSize);
        }

        /// <summary>
        /// Creates a new subchunk with a default block palette size of 8.
        /// </summary>
        public SubChunk() : this(8) {}

        /// <summary>
        /// Create a new subchunk with a default block state and a default block palette size of 8.
        /// </summary>
        /// <param name="defaultBlockState"> The default block state that the subchunk should generate. </param>
        public SubChunk(T defaultBlockState) : this(8)
        {
            BlockPalette.Add(defaultBlockState);
            for(int i = 0; i < 8; i++)
            {
                FillLayer(defaultBlockState, i);
            }
        }

        
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
            int paletteSize = BlockPalette.BlockStates.Length;
            for (int i = 0; i < paletteSize; i++)
            {
                if (EqualityComparer<T>.Default.Equals(BlockPalette.BlockStates[i], blockState))
                {
                    return i;
                }
            }
            return -1;
        }

        public ISubChunk<T> SetBlockState(T blockState, int localX, int localY, int localZ)
        {
            Layers[localY].SetBlockState(this, blockState, localX, localY, localZ);
            return this;
        }

        public ISubChunk<T> Fill(T blockState)
        {
            throw new NotImplementedException();
        }

        public ISubChunk<T> FillLayer(T blockState, int localY)
        {
            if(Layers[localY] is SingleLayeredChunk<T> layer)
            {
                layer.Set(this, blockState, localY);
            }
            else
            {
                Layers[localY] = SharedLayeredChunk<T>.GetOrAdd(this, blockState);
            }

            for(int i = 0; i < SIZE; i++)
            {
                if(!(Layers[i] is SingleLayeredChunk<T> sLayer && EqualityComparer<T>.Default.Equals(sLayer.BlockState, blockState)))
                {
                    return this;
                }
            }
            return Fill(blockState);
        }

        public void SetLayer(ILayeredChunk<T> layer, int localY)
        {
            if(layer is SharedLayeredChunk<T> shared)
            {
                if(!BlockPalette.Has(shared.BlockState))
                {
                    BlockPalette.Add(shared.BlockState);
                }
            }
            Layers[localY] = layer;
        }

        public bool IsAll(Predicate<T> predicate)
        {
            var palette = BlockPalette.BlockStates;
            var paletteSize = palette.Length;
            for(int i = 0; i < paletteSize; i++)
            {
                T blockState = palette[i];
                if (!predicate.Invoke(blockState)) return false;
            }
            return true;
        }

        public bool IsAll(T blockState)
        {
            return BlockPalette.BlockStates.Length == 1 && EqualityComparer<T>.Default.Equals(BlockPalette.Get(0), blockState);
        }
    }
}