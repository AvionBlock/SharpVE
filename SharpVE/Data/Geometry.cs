using System.Collections.Generic;

namespace SharpVE.Data
{
    public class Model
    {
        string Format_Version { get; set; } = string.Empty;
        public List<Geometry> Geometries { get; set; } = new List<Geometry>();
    }

    public class Geometry
    {
        public GeometryDescription Description { get; set; } = new GeometryDescription();
        public List<Bone>? Bones { get; set; }
    }

    public class GeometryDescription
    {
        public string Identifier { get; set; } = string.Empty;
        public float? Visible_Bounds_Width { get; set; }
        public float? Visible_Bounds_Height { get; set; }
        public float[]? Visible_Bounds_Offset { get; set; }
        public int? Texture_Width { get; set; }
        public int? Texture_Height { get; set; }
    }

    public class Bone
    {
        public string Name { get; set; } = string.Empty;
        public string? Parent { get; set; }
        public float[]? Pivot { get; set; }

        public List<Cube>? Cubes { get; set; }
    }

    public class Cube
    {
        float[]? Origin { get; set; }
        float[]? Size { get; set; }
        float[]? Rotation { get; set; }
        float[]? Pivot { get; set; }
        float[]? UV { get; set; }
    }
}
