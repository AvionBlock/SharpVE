namespace SharpVE.Core.Blocks
{
    public class Block
    {
        public BlockState GetBlockState()
        {
            return new BlockState(this);
        }
    }
}
