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
        public const ushort COLUMN_HEIGHT = 256;

        public Vector2D<int> ChunkCoordinates { get; private set; }
        private SubChunk[]? SubChunks;

        public ChunkColumn(Vector2D<int> ChunkCoordinates)
        {
            this.ChunkCoordinates = ChunkCoordinates;

            if (COLUMN_HEIGHT % CHUNK_HEIGHT != 0)
                throw new Exception($"{nameof(COLUMN_HEIGHT)} is not divisible by {nameof(CHUNK_HEIGHT)}");

            SubChunks = new SubChunk[CHUNK_HEIGHT / CHUNK_HEIGHT];
        }

        public void SetBlock(int localX, int localY, int localZ, BlockState block)
        {
            throw new NotImplementedException();
        }

        public void SetBlock(Vector3D<int> localPos, BlockState block)
        {
            SetBlock(localPos.X, localPos.Y, localPos.Z, block);
        }

        public BlockState? GetBlock(int localX, int localY, int localZ)
        {
            throw new NotImplementedException();
        }

        public BlockState? GetBlock(Vector3D<int> globalPos)
        {
            return GetBlock(globalPos.X, globalPos.Y, globalPos.Z);
        }
    }
}
