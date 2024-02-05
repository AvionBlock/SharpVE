using SharpVE.Core.Interfaces.Chunks;
using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks
{
    public class SubChunkData : ISubChunkData
    {
        private SubChunk SubChunk;
        private ILayerData?[] Data;

        public SubChunkData(SubChunk SubChunk)
        {
            this.SubChunk = SubChunk;
            Data = new ILayerData[ChunkColumn.CHUNK_HEIGHT];
        }

        public ushort GetBlock(int localX, int localY, int localZ)
        {
            var layer = Data[localY];
            if (layer == null) return 0;

            return layer.GetBlock(localX, localZ);
        }

        public ushort GetBlock(Vector3D<int> localPos)
        {
            return GetBlock(localPos.X, localPos.Y, localPos.Z);
        }

        public void SetBlock(int localX, int localY, int localZ, ushort blockId)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlock(Vector3D<int> localPos, ushort blockId)
        {
            throw new System.NotImplementedException();
        }
    }
}
