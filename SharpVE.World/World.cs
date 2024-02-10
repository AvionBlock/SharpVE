using SharpVE.Core.Blocks;
using SharpVE.Core.Registries;
using SharpVE.World.Chunks;
using Silk.NET.Maths;
using System;
using System.Collections.Generic;

namespace SharpVE.World
{
    public class World
    {
        public BlockRegistry Blocks { get; set; }
        private Dictionary<Vector2D<int>, ChunkColumn> Chunks;

        public World()
        {
            Chunks = new Dictionary<Vector2D<int>, ChunkColumn>();
            Blocks = new BlockRegistry();
        }

        public void AddChunk(ChunkColumn chunk)
        {
            Chunks.Add(chunk.ChunkCoordinates, chunk);
        }

        public ChunkColumn GetChunk(int globalX, int globalZ)
        {
            //Calculate the X and Z coord of the chunk column from the global position.
            var xCoord = (int)MathF.Floor(globalX / ChunkColumn.CHUNK_WIDTH);
            var zCoord = (int)MathF.Floor(globalZ / ChunkColumn.CHUNK_DEPTH);

            //Get the chunk column.
            Chunks.TryGetValue(new Vector2D<int>(xCoord, zCoord), out var chunkColumn);
            if(chunkColumn == null) throw new Exception($"Chunk at X: {xCoord}, Z: {zCoord} does not exist or is not loaded!");

            return chunkColumn;
        }

        public void RemoveChunk(Vector2D<int> globalPos)
        {
            Chunks.Remove(globalPos);
        }

        public void SetBlock(int globalX, int globalY, int globalZ, BlockState block)
        {
            //Get the chunk column.
            var chunkColumn = GetChunk(globalX, globalZ);

            //Convert global to local position.
            var localX = globalX % ChunkColumn.CHUNK_WIDTH;
            if (localX < 0) localX += ChunkColumn.CHUNK_WIDTH;

            var localZ = globalX % ChunkColumn.CHUNK_DEPTH;
            if (localZ < 0) localZ += ChunkColumn.CHUNK_DEPTH;

            chunkColumn.SetBlock(localX, globalY, localZ, block);
        }

        public void SetBlock(Vector3D<int> globalPos, BlockState block)
        {
            SetBlock(globalPos.X, globalPos.Y, globalPos.Z, block);
        }

        public BlockState? GetBlock(int globalX, int globalY, int globalZ)
        {
            //Get the chunk column.
            var chunkColumn = GetChunk(globalX, globalZ);

            //Convert global to local position.
            var localX = globalX % ChunkColumn.CHUNK_WIDTH;
            if (localX < 0) localX += ChunkColumn.CHUNK_WIDTH;

            var localZ = globalX % ChunkColumn.CHUNK_DEPTH;
            if (localZ < 0) localZ += ChunkColumn.CHUNK_DEPTH;

            return chunkColumn.GetBlock(localX, globalY, localZ);
        }

        public BlockState? GetBlock(Vector3D<int> globalPos)
        {
            return GetBlock(globalPos.X, globalPos.Y, globalPos.Z);
        }
    }
}
