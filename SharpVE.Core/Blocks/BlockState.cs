using System;

namespace SharpVE.Core.Blocks
{
    public class BlockState
    {
        public readonly Block Block;

        public BlockState(Block Block)
        {
            this.Block = Block;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetHashCode().Equals(GetHashCode());
        }
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Block.GetHashCode()); //This just returns the hashcode for the block name.

            //Do a loop and add all states to the hashcode.

            return hash.ToHashCode();
        }
    }
}
