using SharpVE.Interfaces;

namespace SharpVE.Blocks.Properties
{
    public class EnumProperty<T> : Property<T> where T : struct
    {
        protected EnumProperty(string name, T defaultValue) : base(name)
        {
            Default = defaultValue;
        }
    }
}
