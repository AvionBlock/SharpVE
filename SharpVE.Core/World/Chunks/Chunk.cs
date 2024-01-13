using SharpVE.Core.World.Chunks;

namespace SharpVE.Core.World.Chunks
{
    public class Chunk
    {
        //Constants
        public const ushort CHUNK_WIDTH = 16;
        public const ushort CHUNK_DEPTH = 16;
        public const ushort CHUNK_HEIGHT = 16;

        private IChunkData Data { get; set; }

        public Chunk()
        {

        }
    }
}
