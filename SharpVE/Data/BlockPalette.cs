using System;

namespace SharpVE.Data
{
    public class BlockPalette<T>
    {
        public T[] BlockStates;

        public BlockPalette(int defaultSize)
        {
            BlockStates = new T[defaultSize];
        }

        public void Add(T blockState)
        { }

        public T Get(int blockId)
        {
            throw new NotImplementedException();
        }

        public bool Has(T blockState)
        {
            return false;
        }

        public void Clean()
        { }
    }
}
