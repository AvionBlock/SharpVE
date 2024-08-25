using SharpVE.Blocks;
using System;
using System.Collections.Concurrent;

namespace SharpVE.Registries
{
    public class BlockRegistry
    {
        private ConcurrentDictionary<string, Block> RegisteredBlocks { get; set; }

        public BlockRegistry()
        {
            RegisteredBlocks = new ConcurrentDictionary<string, Block>();
        }

        public bool Register(Block block)
        {
            return RegisteredBlocks.TryAdd(block.Identifier, block);
        }

        public bool Unregister(Block block)
        {
            return RegisteredBlocks.TryRemove(block.Identifier, out _);
        }

        public bool Unregister(string identifier)
        {
            return RegisteredBlocks.TryRemove(identifier, out _);
        }

        public Block Get(string identifier)
        {
            if(RegisteredBlocks.TryGetValue(identifier, out var block))
            {
                return block;
            }
            throw new Exception($"Block of type {identifier} was not found!");
        }
    }
}
