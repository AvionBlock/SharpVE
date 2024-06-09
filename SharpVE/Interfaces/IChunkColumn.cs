using SharpVE.Data;

namespace SharpVE.Interfaces
{
    public interface IChunkColumn<T> where T : class //BlockStates must be an object.
    {
        public static int MinY;
        public static int MaxY;
        public static int ColumnHeight = MaxY - MinY;
    }
}