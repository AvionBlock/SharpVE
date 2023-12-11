using SharpVE.Blocks;
using Silk.NET.Maths;

namespace SharpVE.Interfaces
{
    public interface ISubChunk
    {
        /// <summary>
        /// Gets a blockstate in the subchunk.
        /// </summary>
        /// <param name="localPosition"></param>
        /// <returns></returns>
        BlockState? GetBlock(Vector3D<int> localPosition);
    }
}
