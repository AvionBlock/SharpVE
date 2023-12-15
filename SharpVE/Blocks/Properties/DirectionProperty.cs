namespace SharpVE.Blocks.Properties
{
    public class DirectionProperty : Property<Direction>
    {
        protected DirectionProperty(string name) : base(name) { }
    }

    public enum Direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,
        UP,
        DOWN
    }
}
