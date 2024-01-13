using SharpVE.Core.World.Chunk.Section;

namespace SharpVE.Core.World.Chunk
{
    public class ChunkData : IChunkData
    {
        //Constants
        public const ushort CHUNK_WIDTH = 16;
        public const ushort CHUNK_DEPTH = 16;
        public const ushort CHUNK_HEIGHT = 16;

        public ISectionData[]? Sections { get; set; }
        public ChunkData()
        {
            Sections = new ISectionData[CHUNK_HEIGHT];
        }
    }
}
