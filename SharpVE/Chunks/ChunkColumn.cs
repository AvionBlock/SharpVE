using SharpVE.Data;
using SharpVE.Interfaces;
using System;

namespace SharpVE.Chunks
{
    /// <summary>
    /// A chunk column.
    /// </summary>
    public class ChunkColumn<T> where T : class
    {
        public static int MIN_Y; //DO NOT CHANGE THESE AFTER YOU CREATE YOUR FIRST CHUNK COLUMN AT RUNTIME!
        public static int MAX_Y; //DO NOT CHANGE THESE AFTER YOU CREATE YOUR FIRST CHUNK COLUMN AT RUNTIME!
        public static int COLUMN_HEIGHT => MAX_Y - MIN_Y;
        public static int SUBCHUNK_COUNT => (int)MathF.Ceiling(COLUMN_HEIGHT);

        /// <summary>
        /// The subchunks/sections that make up the chunk column.
        /// </summary>
        public ISubChunk<T>[] SubChunks { get; private set; } = new SubChunk<T>[SUBCHUNK_COUNT];

        /// <summary>
        /// Constructs a new chunk column with a default block state.
        /// </summary>
        /// <param name="defaultBlockState">The default block state to set when the chunk column is created.</param>
        public ChunkColumn(T defaultBlockState)
        {
            for (int i = 0; i < SUBCHUNK_COUNT; i++)
            {
                SubChunks[i] = new SingleSubChunk<T>(defaultBlockState);
            }
        }

        /// <summary>
        /// Get's a blockstate <see cref="T"/> in the <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="localX">The local X coordinate inside of <see cref="ChunkColumn{T}"/>.</param>
        /// <param name="y">The global Y coordinate of the <see cref="ChunkColumn{T}"/> within the <see cref="MIN_Y"/> and <see cref="MAX_Y"/> constraints.</param>
        /// <param name="localZ">The local Z coordinate inside of <see cref="ChunkColumn{T}"/></param>
        /// <returns>A blockstate of type <see cref="T"/>.</returns>
        public T GetBlockState(int localX, int y, int localZ)
        {
            var ySection = (y - MIN_Y) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].GetBlockState(localX, localY, localZ);
        }

        /// <summary>
        /// Get's a blockstate <see cref="T"/> in the <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="blockPosition">The <see cref="BlockPosition"/> with the X and Z coordinates already set to the local <see cref="ChunkColumn{T}"/> coordinates with the global Y coordinate between <see cref="MIN_Y"/> and <see cref="MAX_Y"/> constraints.</param>
        /// <returns>A blockstate of type <see cref="T"/>.</returns>
        public T GetBlockState(BlockPosition blockPosition)
        {
            var ySection = (blockPosition.Y - MIN_Y) / ISubChunk<T>.SIZE;
            var localPosition = blockPosition.GetLocalYPosition(ISubChunk<T>.SIZE);
            return SubChunks[ySection].GetBlockState(localPosition.X, localPosition.Y, localPosition.Z);
        }

        /// <summary>
        /// Get's a blockstate ID from the local X, Y and local Z coordinate in the <see cref="ChunkColumn{T}"/>.
        /// </summary>
        /// <param name="localX">The local X in the chunk column.</param>
        /// <param name="y">The y position in the chunk column.</param>
        /// <param name="localZ">The local Z in the chunk column.</param>
        /// <returns>The blockstate ID.</returns>
        public int GetBlockStateID(int localX, int y, int localZ)
        {
            var ySection = (y - MIN_Y) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            return SubChunks[ySection].GetBlockStateID(localX, localY, localZ);
        }

        /// <summary>
        /// Set's a blockstate inside the chunk column.
        /// </summary>
        /// <param name="blockState">The blockstate <see cref="T"/> to set.</param>
        /// <param name="localX">The local X in the chunk column.</param>
        /// <param name="y">The y position in the chunk column.</param>
        /// <param name="localZ">The local Z in the chunk column.</param>
        public void SetBlockState(T blockState, int localX, int y, int localZ)
        {
            var ySection = (y - MIN_Y) / ISubChunk<T>.SIZE;
            var localY = BlockPosition.ToLocalYPosition(y, ISubChunk<T>.SIZE).Y;
            SubChunks[ySection] = SubChunks[ySection].SetBlockState(blockState, localX, localY, localZ);
        }

        /// <summary>
        /// Fills the entire chunk column 
        /// </summary>
        /// <param name="blockState">The blockstate to fill the entire chunk column.</param>
        public void Fill(T blockState)
        {
            for(int i = 0; i < SUBCHUNK_COUNT; i++)
            {
                SubChunks[i] = SubChunks[i].Fill(blockState);
            }
        }

        /// <summary>
        /// Check's if the entire chunk column matches the predicate.
        /// </summary>
        /// <param name="predicate"> The predicate to check against. </param>
        public bool IsAll(Predicate<T> predicate)
        {
            for(int i = 0; i < SUBCHUNK_COUNT; i++)
            {
                if (!SubChunks[i].IsAll(predicate)) return false;
            }
            return true;
        }

        /// <summary>
        /// Check's if the entire chunk column matches the blockstate.
        /// </summary>
        /// <param name="blockState"> The blockstate to check against. </param>
        public bool IsAll(T blockState)
        {
            for (int i = 0; i < SUBCHUNK_COUNT; i++)
            {
                if (!SubChunks[i].IsAll(blockState)) return false;
            }
            return true;
        }

        /// <summary>
        /// Cleans all subchunk block palettes inside the chunk column.
        /// </summary>
        public void CleanPalettes()
        {
            for (int i = 0; i < SUBCHUNK_COUNT; i++)
            {
                if(SubChunks[i] is SubChunk<T> subChunk)
                {
                    subChunk.CleanPalette();
                }
            }
        }
    }
}
