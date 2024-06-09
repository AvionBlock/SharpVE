using SharpVE.Chunks;
using SharpVE.Data;
using SharpVE.Interfaces;
using System;

namespace SharpVE.World.Chunks
{
    /// <summary>
    /// A chunk column.
    /// </summary>
    public class ChunkColumn<T> : IChunkColumn<T> where T : class
    {
        /// <summary>
        /// The chunk position.
        /// </summary>
        public ChunkPosition Position { get; private set; }

        /// <summary>
        /// The subchunks/sections that make up the chunk column.
        /// </summary>
        public ISubChunk<T>[] SubChunks { get; private set; } = new SubChunk<T>[(int)(MathF.Ceiling(IChunkColumn<T>.ColumnHeight))];

        /// <summary>
        /// Constructs a new chunk column.
        /// </summary>
        /// <param name="defaultBlockState">The default block state to set when the chunk column is created.</param>
        /// <param name="x">The X coordinate of the chunk column.</param>
        /// <param name="y">The Y coordinate of the chunk column.</param>
        public ChunkColumn(T defaultBlockState, int x, int y)
        {
            Position = new ChunkPosition(x, y);
            SubChunks = new SubChunk<T>[(int)(MathF.Ceiling(IChunkColumn<T>.ColumnHeight))];
            for (int i = 0; i < SubChunks.Length; i++)
            {
                SubChunks[i] = new SingleSubChunk<T>(defaultBlockState);
            }
        }

        /// <summary>
        /// Constructs a new chunk column.
        /// </summary>
        /// <param name="defaultBlockState">The default block state to set when the chunk column is created.</param>
        /// <param name="position">The position of the chunk column.</param>
        public ChunkColumn(T defaultBlockState, ChunkPosition position)
        {
            Position = position;
            for (int i = 0; i < SubChunks.Length; i++)
            {
                SubChunks[i] = new SingleSubChunk<T>(defaultBlockState);
            }
        }

        public T GetBlockState(int localX, int y, int localZ)
        {
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[localY].GetBlockState(localX, localY, localZ);
        }

        public int GetBlockStateID(int localX, int y, int localZ)
        {
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[localY].GetBlockStateID(localX, localY, localZ);
        }

        public IChunkColumn<T> SetBlockState(T blockState, int localX, int y, int localZ)
        {
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            SubChunks[localY].SetBlockState(blockState, localX, localY, localZ);
            return this;
        }

        public IChunkColumn<T> Fill(T blockState)
        {
            return new SingleChunkColumn<T>();
        }

        public ISubChunk<T> FillSubChunk(T blockState, int y)
        {
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[localY].Fill(blockState);
        }

        public ISubChunk<T> FillLayer(T blockState, int y)
        {
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[localY].FillLayer(blockState, localY);
        }

        public bool IsAll(Predicate<T> predicate)
        {

        }

        public bool IsAll(T blockState)
        {

        }

        public void CleanPalettes()
        {

        }
    }
}
