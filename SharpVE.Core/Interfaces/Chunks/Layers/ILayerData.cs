using Silk.NET.Maths;

namespace SharpVE.Core.Interfaces.Chunks.Layers
{
    public interface ILayerData
    {
        /// <summary>
        /// Gets a block id from the layer that references a blockstate.
        /// </summary>
        /// <param name="localX">Local X coordinate inside the layer.</param>
        /// <param name="localZ">Local Z coordinate inside the layer.</param>
        /// <returns>The block id.</returns>
        ushort GetBlock(int localX, int localZ);

        /// <summary>
        /// Gets a block id from the layer that references a blockstate.
        /// </summary>
        /// <param name="localPos">Local X,Z coordinate inside the layer.</param>
        /// <returns>The block id.</returns>
        ushort GetBlock(Vector2D<int> localPos);

        /// <summary>
        /// Sets a block id into the layer.
        /// </summary>
        /// <param name="localX">Local X coordinate inside the layer.</param>
        /// <param name="localZ">Local Z coordinate inside the layer.</param>
        /// <param name="blockId">The block id reference.</param>
        void SetBlock(int localX, int localZ, ushort blockId);

        /// <summary>
        /// Sets a block id into the layer.
        /// </summary>
        /// <param name="localPos">Local X,Z coordinate inside the layer.</param>
        /// <param name="blockId">The block id reference.</param>
        void SetBlock(Vector2D<int> localPos, ushort blockId);
    }
}
