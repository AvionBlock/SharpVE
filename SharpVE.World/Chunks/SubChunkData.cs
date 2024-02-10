using SharpVE.Core.Interfaces.Chunks;
using SharpVE.Core.Interfaces.Chunks.Layers;
using SharpVE.World.Chunks.Layers;
using Silk.NET.Maths;
using System;

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

        public void AddOrReplaceLayer(ILayerData layer, int yLayer)
        {
            if (yLayer > ChunkColumn.CHUNK_HEIGHT)
                throw new Exception($"yLayer of {yLayer} exceeds the chunk height of {ChunkColumn.CHUNK_HEIGHT}");

            Data[yLayer] = layer;
        }

        public ILayerData GetOrCreateLayer(int yLayer)
        {
            var layer = Data[yLayer];
            if(layer == null)
                layer = new SingleBlockLayerData(this);

            return layer;
        }

        public void RemoveLayer(int yLayer)
        {
            Data[yLayer] = null;
        }

        public ushort GetBlock(int localX, int localY, int localZ)
        {
            if (!CoordinateIsValid(localX, localY, localZ)) return 0;
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
            if (!CoordinateIsValid(localX, localY, localZ)) return;
            var layer = GetOrCreateLayer(localY);
            if (layer is SingleBlockLayerData)
            {
                layer = new LayerData(this);
                AddOrReplaceLayer(new LayerData(this), localY);
            }
            layer.SetBlock(localX, localZ, blockId);
        }

        public void SetBlock(Vector3D<int> localPos, ushort blockId)
        {
            SetBlock(localPos.X, localPos.Y, localPos.Z, blockId);
        }

        private bool CoordinateIsValid(int localX, int localY, int localZ)
        {
            if (localX < 0 || localY < 0 || localZ < 0 || localX >= ChunkColumn.CHUNK_WIDTH || localY >= ChunkColumn.CHUNK_HEIGHT || localZ >= ChunkColumn.CHUNK_DEPTH) return false;
            return true;
        }
    }
}
