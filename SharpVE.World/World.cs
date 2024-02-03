using SharpVE.Core.Blocks;
using SharpVE.World.Chunks;
using Silk.NET.Maths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpVE.World
{
    public class World
    {
        private List<ChunkColumn> Chunks { get; set; } = new List<ChunkColumn>();

        public World() { }

        public void AddChunk(ChunkColumn chunk)
        {
            Chunks.Add(chunk);
        }

        public ChunkColumn GetChunk(int globalX, int globalZ)
        {
            //Calculate the X and Z coord of the chunk column from the global position.
            var xCoord = (int)MathF.Floor(globalX / ChunkColumn.CHUNK_WIDTH);
            var zCoord = (int)MathF.Floor(globalZ / ChunkColumn.CHUNK_DEPTH);

            //Get the chunk column.
            var chunkColumn = Chunks.FirstOrDefault(x => x.ChunkCoordinates.X == xCoord && x.ChunkCoordinates.Y == zCoord);
            if(chunkColumn == null) throw new Exception($"Chunk at X: {xCoord}, Z: {zCoord} does not exist or is not loaded!");

            return chunkColumn;
        }

        public void RemoveChunk(ChunkColumn chunk)
        {
            Chunks.Remove(chunk);
        }

        public void SetBlock(int globalX, int globalY, int globalZ, BlockState block)
        {
            //Get the chunk column.
            var chunkColumn = GetChunk(globalX, globalZ);

            //Convert global to local position.
            var localX = globalX % ChunkColumn.CHUNK_WIDTH;
            if (localX < 0) localX += ChunkColumn.CHUNK_WIDTH;

            var localY = globalY - ChunkColumn.MIN_Y;

            var localZ = globalX % ChunkColumn.CHUNK_DEPTH;
            if (localZ < 0) localZ += ChunkColumn.CHUNK_DEPTH;

            chunkColumn.SetBlock(localX, localY, localZ, block);
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

            var localY = globalY - ChunkColumn.MIN_Y;

            var localZ = globalX % ChunkColumn.CHUNK_DEPTH;
            if (localZ < 0) localZ += ChunkColumn.CHUNK_DEPTH;

            return chunkColumn.GetBlock(localX, localY, localZ);
        }

        public BlockState? GetBlock(Vector3D<int> globalPos)
        {
            return GetBlock(globalPos.X, globalPos.Y, globalPos.Z);
        }
    }
}
