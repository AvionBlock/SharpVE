using System;
using System.Diagnostics;
using SharpVE.Chunks.Layers;
using SharpVE.Data;
using SharpVE.Interfaces;

namespace SharpVE.Chunks
{
    /// <summary>
    /// A subchunk.
    /// </summary>
    public class SubChunk<T> : ISubChunk<T> where T : class
    {
        private bool AllowPaletteCleaning = true;

        /// <summary>
        /// The block palette inside the subchunk.
        /// </summary>
        public BlockPalette<T> BlockPalette { get; private set; }

        /// <summary>
        /// The layers that make up the subchunk. Each layer contains block data.
        /// </summary>
        public ILayeredChunk<T>[] Layers { get; private set; } = new ILayeredChunk<T>[ISubChunk<T>.SIZE];

        /// <summary>
        /// Create a new subchunk with a default block state and a default block palette size of 8.
        /// </summary>
        /// <param name="defaultBlockState"> The default block state that the subchunk should generate. </param>
        public SubChunk(T defaultBlockState, int defaultPaletteSize = 8)
        {
            BlockPalette = new BlockPalette<T>(defaultPaletteSize);
            BlockPalette.Add(defaultBlockState);
            for(int i = 0; i < 8; i++)
            {
                FillLayer(defaultBlockState, i);
            }
        }

        /// <summary>
        /// Get's a blockstate on the localX, localY and localZ coordinates.
        /// </summary>
        /// <param name="localX"> The local X coordinate </param>
        /// <param name="localY"> The local Y coordinate </param>
        /// <param name="localZ"> The local Z coordinate </param>
        public T GetBlockState(int localX, int localY, int localZ)
        {
            return Layers[localY].GetBlockState(this, localX, localZ);
        }

        /// <summary>
        /// Get's a blockstate ID on the localX, localY and localZ coordinates.
        /// </summary>
        /// <param name="localX"> The local X coordinate </param>
        /// <param name="localY"> The local Y coordinate </param>
        /// <param name="localZ"> The local Z coordinate </param>
        public int GetBlockStateID(int localX, int localY, int localZ)
        {
            return Layers[localY].GetBlockStateID(this, localX, localZ);
        }

        /// <summary>
        /// Get's a blockstate ID from a blockState instance.
        /// </summary>
        /// <param name="blockState"> The blockstate instance </param>
        public int GetBlockStateID(T blockState)
        {
            int paletteSize = GetBlockPaletteSize();
            for (int i = 0; i < paletteSize; i++)
            {
                if (BlockPalette.BlockStates[i] == blockState)
                {
                    return i;
                }
            }
            return -1;
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
            Layers[localY].SetBlockState(this, blockState, localX, localY, localZ);
            return this;
        }

        /// <summary>
        /// Fills the subchunk with a blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to fill the subchunk with. </param>
        public ISubChunk<T> Fill(T blockState)
        {
            return new SingleSubChunk<T>(blockState);
        }

        /// <summary>
        /// Fills a layer with a blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to fill the layer with. </param>
        /// <param name="localY"> The local Y layer to set. </param>
        public ISubChunk<T> FillLayer(T blockState, int localY)
        {
            if(Layers[localY] is SingleLayeredChunk<T> layer)
            {
                layer.Fill(this, blockState, localY);
            }
            else
            {
                Layers[localY] = SharedLayeredChunk<T>.GetOrAdd(this, blockState);
            }

            for(int i = 0; i < ISubChunk<T>.SIZE; i++)
            {
                if(!(Layers[i] is SingleLayeredChunk<T> sLayer && sLayer.BlockState == blockState))
                {
                    return this;
                }
            }
            return Fill(blockState);
        }

        /// <summary>
        /// Set's a layer on the specified Y layer.
        /// </summary>
        /// <param name="layer"> The layer to replace with. </param>
        /// <param name="localY"> The local Y layer to set. </param>
        public void SetLayer(ILayeredChunk<T> layer, int localY)
        {
            if(layer is SharedLayeredChunk<T> shared)
            {
                if(!BlockPalette.Has(this, shared.BlockState))
                {
                    BlockPalette.Add(shared.BlockState);
                }
            }
            Layers[localY] = layer;
        }

        /// <summary>
        /// Check's if the entire subchunk matches the predicate.
        /// </summary>
        /// <param name="predicate"> The predicate to check against. </param>
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

        /// <summary>
        /// Check's if the entire subchunk matches the blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to check against. </param>
        public bool IsAll(T blockState)
        {
            return GetBlockPaletteSize() == 1 && BlockPalette.Get(0) == blockState;
        }

        /// <summary>
        /// Cleans unused blockstates from the subchunk blockstate palette.
        /// </summary>
        public void CleanPalette()
        {
            if (!AllowPaletteCleaning) return; //Prevent recursions.

            var currentSize = GetBlockPaletteSize();
            SubChunk<T> tempSubChunk = new SubChunk<T>(GetBlockState(0, 0, 0));
            tempSubChunk.AllowPaletteCleaning = false;
            for (int x = 0; x < ISubChunk<T>.SIZE; x++)
            {
                for (int y = 0; y < ISubChunk<T>.SIZE; y++)
                {
                    for (int z = 0; z < ISubChunk<T>.SIZE; z++)
                    {
                        var currentBlockState = GetBlockState(x, y, z);
                        tempSubChunk.SetBlockState(currentBlockState, x, y, z);
                    }
                }
            }

            BlockPalette.CopyFromPalette(tempSubChunk.BlockPalette);
            Layers = tempSubChunk.Layers;

            var amountRemoved = currentSize - tempSubChunk.GetBlockPaletteSize();
            Debug.WriteLine($"Cleaned {amountRemoved} blockstates from the palette.");
            
            if(GetBlockPaletteSize() > ISubChunk<T>.NUM_OF_BLOCKS)
            {
                throw new Exception("Failed to clean palette: This should never happen.");
            }
        }

        /// <summary>
        /// Get's the size of the block palette.
        /// </summary>
        /// <returns>The size of all the unique blocks.</returns>
        public int GetBlockPaletteSize()
        {
            return BlockPalette.Size;
        }
    }
}