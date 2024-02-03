using SharpVE.Core.Interfaces.Chunks;

namespace SharpVE.World.Chunks
{
    public class SubChunk
    {
        private ChunkColumn ChunkColumn;
        private ISubChunkData Data;

        public SubChunk(ChunkColumn ChunkColumn)
        {
            this.ChunkColumn = ChunkColumn;
            //TEMPORARY
            Data = new SingleBlockSubChunkData(this);
        }
    }
}
