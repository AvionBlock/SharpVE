using SharpVE.Interfaces;
using System;
using System.Collections.Generic;

namespace SharpVE.Blocks
{
    public class BlockState
    {
        public Block Block { get; set; }
        public short Data { get; set; }
        public Dictionary<string, IProperty> States { get; } = new Dictionary<string, IProperty>();

        public BlockState(Block block)
        {
            Block = block;
        }

        public void SetState(string name, IProperty value)
        {
            if (States.ContainsKey(name))
            {
                States[name] = value;
            }
            else
            {
                States.TryAdd(name, value);
            }
        }

        protected bool Equals(BlockState other)
        {
            var result = Block == other.Block;
            if (!result) return false;

            var states = new HashSet<KeyValuePair<string, IProperty>>(States);
            var otherStates = new HashSet<KeyValuePair<string, IProperty>>(other.States);

            otherStates.IntersectWith(states);
            result = otherStates.Count == states.Count;
            
            return result;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != GetType()) return false;
            return Equals((BlockState)obj);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Block); //Same block?
            foreach(var property in States)
            {
                hash.Add(property);
            }
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(Block)}: {Block.Identifier}, {nameof(Data)}: {Data}, {nameof(States)} {{ {string.Join(';', States)} }}";
        }
    }
}
