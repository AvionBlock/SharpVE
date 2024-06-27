using SharpVE.Data;
using SharpVE.Interfaces;
using System.Collections.Generic;

namespace SharpVE.Blocks
{
    public class Block
    {
        Dictionary<string, IProperty> PropertyMap { get; set; }

        public string Identifier { get; }
        public Geometry? Geometry { get; set; } //Need to make this ECS

        public bool IsSolid { get; set; }
        public bool IsAlpha { get; set; } //Transparent

        public Block(string identifier)
        {
            Identifier = identifier;
            PropertyMap = new Dictionary<string, IProperty>();
        }
    }
}
