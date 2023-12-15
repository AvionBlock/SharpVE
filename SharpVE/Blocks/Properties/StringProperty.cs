namespace SharpVE.Blocks.Properties
{
    public class StringProperty : Property<string>
    {
        private string DefaultValue;

        protected StringProperty(string name, string defaultValue) : base(name)
        {
            DefaultValue = defaultValue;
            Value = defaultValue;
        }
    }
}
