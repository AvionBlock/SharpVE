using SharpVE.Core.Interfaces.Chunks.Layers;
using Silk.NET.Maths;

namespace SharpVE.World.Chunks.Layers
{
    public class SingleBlockLayerData : ILayerData
    {
        public ushort GetBlock(int localX, int localZ)
        {
            throw new System.NotImplementedException();
        }

        public ushort GetBlock(Vector2D<int> localPos)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlock(int localX, int localZ, ushort blockId)
        {
            throw new System.NotImplementedException();
        }

        public void SetBlock(Vector2D<int> localPos, ushort blockId)
        {
            throw new System.NotImplementedException();
        }
    }
}
