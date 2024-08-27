using SharpVE.Blocks;
using System;
using System.Collections.Concurrent;

namespace SharpVE.Registries
{
    public static class BlockRegistry
    {
        private static ConcurrentDictionary<string, Block> RegisteredBlocks = new ConcurrentDictionary<string, Block>();

        public static bool Register(Block block)
        {
            return RegisteredBlocks.TryAdd(block.Identifier, block);
        }

        public static bool Unregister(Block block)
        {
            return RegisteredBlocks.TryRemove(block.Identifier, out _);
        }

        public static bool Unregister(string identifier)
        {
            return RegisteredBlocks.TryRemove(identifier, out _);
        }

        public static Block Get(string identifier)
        {
            if(RegisteredBlocks.TryGetValue(identifier, out var block))
            {
                return block;
            }
            throw new Exception($"Block of type {identifier} was not found!");
        }
    }
}
