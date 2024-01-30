﻿using SharpVE.Core.World.Chunks;
using System;

namespace SharpVE.Core.World.Chunks
{
    public class ChunkColumn
    {
        //Constants
        public const ushort CHUNK_WIDTH = 16;
        public const ushort CHUNK_DEPTH = 16;
        public const ushort CHUNK_HEIGHT = 16;
        public const ushort COLUMN_HEIGHT = 256;

        private SubChunk[] SubChunks;

        public ChunkColumn()
        {
            if (COLUMN_HEIGHT % CHUNK_HEIGHT != 0)
                throw new Exception("COLUMN_HEIGHT is not divisible by CHUNK_HEIGHT");

            SubChunks = new SubChunk[CHUNK_HEIGHT / CHUNK_HEIGHT];
        }
    }
}
