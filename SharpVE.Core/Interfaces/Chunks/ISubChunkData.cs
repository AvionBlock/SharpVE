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
        /// <returns>The block id.</returns>
        ushort GetBlock(int localX, int localY, int localZ);

        /// <summary>
        /// Gets a blockstate from the subchunk.
        /// </summary>
        /// <param name="localPos">The local X,Y,Z coordinate inside the subchunk.</param>
        /// <returns>The block id.</returns>
        ushort GetBlock(Vector3D<int> localPos);

        /// <summary>
        /// Sets a blockstate into the subchunk.
        /// </summary>
        /// <param name="localX">The local X coordinate inside the subchunk.</param>
        /// <param name="localY">The local Y coordinate inside the subchunk.</param>
        /// <param name="localZ">The local Z coordinate inside the subchunk.</param>
        /// <param name="blockId">The block id reference.</param>
        void SetBlock(int localX, int localY, int localZ, ushort blockId);

        /// <summary>
        /// Sets a blockstate into the subchunk.
        /// </summary>
        /// <param name="localPos">The local X,Y,Z coordinate inside the subchunk.</param>
        /// <param name="blockId">The block id to set.</param>
        void SetBlock(Vector3D<int> localPos, ushort blockId);
    }
}
