namespace SharpVE.Blocks
{
    public class Block
    {
        private ushort Flags;

        public bool IsLiquid { get => GetFlagBit(1); set => SetFlagBit(1, value); }
        public bool IsTransparent { get => GetFlagBit(2); set => SetFlagBit(2, value); }
        public bool IsFullCube { get => GetFlagBit(3); set => SetFlagBit(3, value); }

        public BlockState State { get; set; }

        public Block()
        {
            IsLiquid = false;
            IsTransparent = false;
            IsFullCube = true;

            State = new BlockState(this);
        }

        private bool GetFlagBit(int bit) => (Flags & (1 << bit)) != 0;
        private void SetFlagBit(int bit, bool value)
        {
            var mask = (ushort)(1 << bit);

            if (value)
            {
                Flags |= mask;
            }
            else
            {
                Flags = (ushort)(Flags & ~mask);
            }
        }
    }
}
