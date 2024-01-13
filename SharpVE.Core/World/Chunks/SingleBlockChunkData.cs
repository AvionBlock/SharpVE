using SharpVE.Core.World.Chunks;

namespace SharpVE.Core.World.Chunks
{
    public class SingleBlockChunkData : IChunkData
    {
        private Chunk PChunk;
        public SingleBlockChunkData(Chunk PChunk)
        {
            this.PChunk = PChunk;
        }
    }
}
