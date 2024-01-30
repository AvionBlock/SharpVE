using SharpVE.Core.Blocks;
using Silk.NET.Maths;

namespace SharpVE.Core.Interfaces.Chunks
{
    public interface ISubChunkData
    {
        /// <summary>
        /// Gets a blockstate from the subchunk.
        /// </summary>
        /// <param name="localX">The local X coordinate inside the subchunk.</param>
        /// <param name="localY">The local Y coordinate inside the subchunk.</param>
        /// <param name="localZ">The local Z coordinate inside the subchunk.</param>
        /// <returns>The blockstate.</returns>
        BlockState? GetBlock(int localX, int localY, int localZ);

        /// <summary>
        /// Gets a blockstate from the subchunk.
        /// </summary>
        /// <param name="localPos">The local X,Y,Z coordinate inside the subchunk.</param>
        /// <returns>The blockstate.</returns>
        BlockState? GetBlock(Vector3D<int> localPos);

        /// <summary>
        /// Sets a blockstate into the subchunk.
        /// </summary>
        /// <param name="localX">The local X coordinate inside the subchunk.</param>
        /// <param name="localY">The local Y coordinate inside the subchunk.</param>
        /// <param name="localZ">The local Z coordinate inside the subchunk.</param>
        /// <param name="block">The blockstate to set.</param>
        void SetBlock(int localX, int localY, int localZ, BlockState block);

        /// <summary>
        /// Sets a blockstate into the subchunk.
        /// </summary>
        /// <param name="localPos">The local X,Y,Z coordinate inside the subchunk.</param>
        /// <param name="block">The blockstate to set.</param>
        void SetBlock(Vector3D<int> localPos, BlockState block);
    }
}
