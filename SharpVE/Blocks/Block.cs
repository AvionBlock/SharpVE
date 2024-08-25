using SharpVE.Interfaces;
using System.Collections.Generic;

namespace SharpVE.Blocks
{
    public class Block
    {
        private Dictionary<string, IProperty> propertyMap { get; set; }

        public string Identifier { get; }

        public bool IsSolid { get; set; }
        public bool IsAlpha { get; set; } //Transparent

        public Block(string identifier, Dictionary<string, IProperty> propertyMap)
        {
            Identifier = identifier;
            this.propertyMap = propertyMap;
        }

        public BlockState GetDefaultBlockState()
        {
            var blockState = new BlockState(this);
            foreach(var property in propertyMap)
            {
                blockState.SetState(property.Key, property.Value);
            }
            return blockState;
        }
    }
}
