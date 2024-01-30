using Silk.NET.Maths;

namespace SharpVE.Core.Interfaces.Chunks.Layers
{
    public interface ILayerData
    {
        ushort GetBlock(int localX, int localZ);
        ushort GetBlock(Vector2D<int> localPos);
        void SetBlock(int localX, int localZ, ushort blockId);
        void SetBlock(Vector2D<int> localPos, ushort blockId);
    }
}
