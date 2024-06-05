namespace SharpVE.Data
{
    public class BlockPalette<T>
    {
        public T[] BlockStates;
        public int Size;

        public void Add(T blockState)
        { }

        public void Get(int blockId)
        { }

        public bool Has(T blockState)
        {
            return false;
        }

        public void Clean()
        { }
    }
}
