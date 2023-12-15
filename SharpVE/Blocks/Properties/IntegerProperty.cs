using SharpVE.Interfaces;

namespace SharpVE.Blocks.Properties
{
    public class IntegerProperty : Property<int>
    {
        private readonly int DefaultValue;

        protected IntegerProperty(string name, int defaultValue) : base(name)
        {
            DefaultValue = defaultValue;
            Value = defaultValue;
        }
    }
}
