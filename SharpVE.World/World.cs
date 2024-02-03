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

        public void RemoveChunk(ChunkColumn chunk)
        {
            Chunks.Remove(chunk);
        }

        public void SetBlock(int globalX, int globalY, int globalZ, BlockState block)
        {

        }

        public void SetBlock(Vector3D<int> globalPos, BlockState block)
        {
            SetBlock(globalPos.X, globalPos.Y, globalPos.Z, block);
        }

        public BlockState? GetBlock(int globalX, int globalY, int globalZ)
        {
            var chunkColumn = Chunks.FirstOrDefault(x => x.ChunkCoordinates.X == MathF.Floor(globalX) && x.ChunkCoordinates.Y == MathF.Floor(globalZ));
            if(chunkColumn == null) return null;


        }

        public BlockState? GetBlock(Vector3D<int> globalPos)
        {
            return GetBlock(globalPos.X, globalPos.Y, globalPos.Z);
        }
    }
}
