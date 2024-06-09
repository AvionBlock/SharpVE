using SharpVE.Data;

namespace SharpVE.Interfaces
{
    public interface IChunkColumn<T>
    {
        public static int MinY;
        public static int MaxY;
        public static int ColumnHeight = MaxY - MinY;

        ChunkPosition Position { get; }
    }
}
