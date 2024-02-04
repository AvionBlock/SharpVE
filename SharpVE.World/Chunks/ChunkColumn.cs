using SharpVE.Core.Blocks;
using Silk.NET.Maths;
using System;

namespace SharpVE.World.Chunks
{
    public class ChunkColumn
    {
        //Constants
        public const ushort CHUNK_WIDTH = 16;
        public const ushort CHUNK_DEPTH = 16;
        public const ushort CHUNK_HEIGHT = 16;

        public const int COLUMN_HEIGHT = 256;
        public const int MAX_Y = COLUMN_HEIGHT + MIN_Y;
        public const int MIN_Y = 0;

        public Vector2D<int> ChunkCoordinates { get; private set; }
        private SubChunk?[] SubChunks;
        private int MIN_Y_LEVEL;
        private int MAX_Y_LEVEL;

        public ChunkColumn(Vector2D<int> ChunkCoordinates)
        {
            this.ChunkCoordinates = ChunkCoordinates;

            MIN_Y_LEVEL = (int)MathF.Floor(MIN_Y / CHUNK_HEIGHT);
            MAX_Y_LEVEL = (int)MathF.Ceiling(MAX_Y / CHUNK_HEIGHT);

            SubChunks = new SubChunk[COLUMN_HEIGHT / CHUNK_HEIGHT];
        }

        public void AddOrReplaceSubChunk(SubChunk subChunk)
        {
            if(subChunk.YLevel * CHUNK_HEIGHT > MAX_Y_LEVEL || subChunk.YLevel * CHUNK_HEIGHT < MIN_Y_LEVEL)
                throw new Exception($"SubChunk y level of {subChunk.YLevel} exceeds the chunk column min/max y level!");

            var yIndex = subChunk.YLevel - MIN_Y_LEVEL;
            SubChunks[yIndex] = subChunk;
        }

        public SubChunk? GetSubChunk(int globalY)
        {
            var yLevel = (int)MathF.Floor(globalY / CHUNK_HEIGHT);
            return SubChunks[yLevel];
        }

        public void RemoveSubChunk(int globalY)
        {
            var yLevel = (int)MathF.Floor(globalY / CHUNK_HEIGHT);
            SubChunks[yLevel] = null;
        }

        public void SetBlock(int localX, int globalY, int localZ, BlockState block)
        {
            var subChunk = GetSubChunk(globalY);
            if (subChunk == null)
            {
                subChunk = new SubChunk(this, (sbyte)MathF.Floor(globalY / CHUNK_HEIGHT));
                AddOrReplaceSubChunk(subChunk); 
            }

            var localY = globalY - (CHUNK_HEIGHT * subChunk.YLevel); //IK BODMAS APPLIES BUT IDK!
            subChunk.SetBlock(localX, localY, localZ, block);
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            SetBlock(localPos.X, localPos.Y, localPos.Z, block);
        }

        public BlockState? GetBlock(int localX, int globalY, int localZ)
        {
            var subChunk = GetSubChunk(globalY);
            if (subChunk == null) return null;

            var localY = globalY - (CHUNK_HEIGHT * subChunk.YLevel); //IK BODMAS APPLIES BUT IDK!
            return subChunk.GetBlock(localX, localY, localZ);
        }

        public BlockState? GetBlock(Vector3D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y, localPos.Z);
        }
    }
}
