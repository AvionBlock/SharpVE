namespace SharpVE.Core.World.Chunks.Layers
{
    public class LayeredChunkData : ILayeredChunkData
    {
        private ushort[] BlockIds { get; set; }
        private ChunkData PChunkData { get; set; }

        public LayeredChunkData(ChunkData PChunkData)
        {
            this.PChunkData = PChunkData;
            BlockIds = new ushort[Chunk.CHUNK_WIDTH * Chunk.CHUNK_DEPTH];
        }
    }
}
