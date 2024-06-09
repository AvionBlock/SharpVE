using SharpVE.Data;
using SharpVE.Interfaces;
using System;

namespace SharpVE.Chunks
{
    /// <summary>
    /// A chunk column.
    /// </summary>
    public class ChunkColumn<T> : IChunkColumn<T> where T : class
    {
        /// <summary>
        /// The subchunks/sections that make up the chunk column.
        /// </summary>
        public ISubChunk<T>[] SubChunks { get; private set; } = new SubChunk<T>[(int)(MathF.Ceiling(IChunkColumn<T>.ColumnHeight))];

        /// <summary>
        /// Constructs a new chunk column.
        /// </summary>
        public ChunkColumn()
        {
            for (int i = 0; i < SubChunks.Length; i++)
            {
                SubChunks[i] = new SingleSubChunk<T>();
            }
        }

        /// <summary>
        /// Constructs a new chunk column.
        /// </summary>
        /// <param name="defaultBlockState">The default block state to set when the chunk column is created.</param>
        public ChunkColumn(T defaultBlockState)
        {
            SubChunks = new SubChunk<T>[(int)(MathF.Ceiling(IChunkColumn<T>.ColumnHeight))];
            for (int i = 0; i < SubChunks.Length; i++)
            {
                SubChunks[i] = new SingleSubChunk<T>(defaultBlockState);
            }
        }

        /// <summary>
        /// Get's a blockstate <see cref="T"/> in the <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="localX">The local X coordinate inside of <see cref="ChunkColumn{T}"/>.</param>
        /// <param name="y">The global Y coordinate of the <see cref="ChunkColumn{T}"/> within the <see cref="IChunkColumn{T}.MinY"/> and <see cref="IChunkColumn{T}.MaxY"/> constraints.</param>
        /// <param name="localZ">The local Z coordinate inside of <see cref="ChunkColumn{T}"/></param>
        /// <returns>A blockstate of type <see cref="T"/>.</returns>
        public T GetBlockState(int localX, int y, int localZ)
        {
            var ySection = (y - IChunkColumn<T>.MinY) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].GetBlockState(localX, localY, localZ);
        }

        /// <summary>
        /// Get's a blockstate <see cref="T"/> in the <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="blockPosition">The <see cref="BlockPosition"/> with the X and Z coordinates already set to the local <see cref="ChunkColumn{T}"/> coordinates with the global Y coordinate between <see cref="IChunkColumn{T}.MinY"/> and <see cref="IChunkColumn{T}.MaxY"/> constraints.</param>
        /// <returns>A blockstate of type <see cref="T"/>.</returns>
        public T GetBlockState(BlockPosition blockPosition)
        {
            var ySection = (blockPosition.Y - IChunkColumn<T>.MinY) / ISubChunk<T>.SIZE;
            var localPosition = blockPosition.GetLocalYPosition(ISubChunk<T>.SIZE);
            return SubChunks[ySection].GetBlockState(localPosition.X, localPosition.Y, localPosition.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localX"></param>
        /// <param name="y"></param>
        /// <param name="localZ"></param>
        /// <returns></returns>
        public int GetBlockStateID(int localX, int y, int localZ)
        {
            var ySection = (y - IChunkColumn<T>.MinY) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].GetBlockStateID(localX, localY, localZ);
        }

        public ISubChunk<T> SetBlockState(T blockState, int localX, int y, int localZ)
        {
            var ySection = (y - IChunkColumn<T>.MinY) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].SetBlockState(blockState, localX, localY, localZ);
        }

        public IChunkColumn<T> Fill(T blockState)
        {
            return new SingleChunkColumn<T>();
        }

        public ISubChunk<T> FillSubChunk(T blockState, int y)
        {
            var ySection = (y - IChunkColumn<T>.MinY) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].Fill(blockState);
        }

        public ISubChunk<T> FillLayer(T blockState, int y)
        {
            var ySection = (y - IChunkColumn<T>.MinY) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].FillLayer(blockState, localY);
        }

        public bool IsAll(Predicate<T> predicate)
        {
            for(int i = 0; i < SubChunks.Length; i++)
            {
                if (!SubChunks[i].IsAll(predicate)) return false;
            }
            return true;
        }

        public bool IsAll(T blockState)
        {
            for (int i = 0; i < SubChunks.Length; i++)
            {
                if (!SubChunks[i].IsAll(blockState)) return false;
            }
            return true;
        }

        public void CleanPalettes()
        {
            for (int i = 0; i < SubChunks.Length; i++)
            {
                if(SubChunks[i] is SubChunk<T> subChunk)
                {
                    subChunk.CleanPalette();
                }
            }
        }
    }
}
