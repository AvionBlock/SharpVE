using SharpVE.Blocks;
using Silk.NET.Maths;

namespace SharpVE.Interfaces
{
    public interface ILayerData
    {
        /// <summary>
        /// Gets a blockstate in the layer.
        /// </summary>
        /// <param name="localPosition"></param>
        /// <returns></returns>
        BlockState? GetBlock(Vector2D<int> localPosition);
    }
}
