﻿using SharpVE.Blocks;

namespace SharpVE.Registries
{
    public class BlockRegistry
    {
        public Dictionary<string, Block> Blocks;
        public Block DefaultBlock => Blocks.Values.ElementAt(0);
        public Block UnknownBlock => Blocks.Values.ElementAt(1);

        public BlockRegistry()
        {
            Blocks = new Dictionary<string, Block>();
        }

        public Block GetBlock(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
