namespace SharpVE.Chunks
{
    /// <summary>
    /// A subchunk.
    /// </summary>
    public class SubChunk
    {
        public static ushort SIZE = 16; //Default.
        public static ushort NUM_OF_BLOCKS = (ushort)(SIZE ^ 3);
    }
}
