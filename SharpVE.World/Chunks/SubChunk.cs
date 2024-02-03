using SharpVE.Core.Interfaces.Chunks;

namespace SharpVE.World.Chunks
{
    public class SubChunk
    {
        public readonly sbyte YLevel;

        private ChunkColumn ChunkColumn;
        private ISubChunkData Data;

        public SubChunk(ChunkColumn ChunkColumn, sbyte yLevel)
        {
            this.ChunkColumn = ChunkColumn;
            Data = new SingleBlockSubChunkData(this);
            YLevel = yLevel;
        }
    }
}
