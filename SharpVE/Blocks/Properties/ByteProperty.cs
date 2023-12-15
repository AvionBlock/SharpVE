namespace SharpVE.Blocks.Properties
{
    public class ByteProperty : Property<byte>
    {
        private readonly byte DefaultValue;

        protected ByteProperty(string name, byte defaultValue) : base(name)
        {
            DefaultValue = defaultValue;
            Value = defaultValue;
        }
    }
}
