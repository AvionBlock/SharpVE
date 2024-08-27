using SharpVE.Data;
using System;
using System.Collections.Concurrent;

namespace SharpVE.Registries
{
    public static class GeometryRegistry
    {
        private static ConcurrentDictionary<string, Geometry> RegisteredGeometries = new ConcurrentDictionary<string, Geometry>();

        public static bool Register(Geometry geometry)
        {
            return RegisteredGeometries.TryAdd(geometry.Description.Identifier, geometry);
        }

        public static bool Unregister(Geometry geometry)
        {
            return RegisteredGeometries.TryRemove(geometry.Description.Identifier, out _);
        }

        public static bool Unregister(string identifier)
        {
            return RegisteredGeometries.TryRemove(identifier, out _);
        }

        public static Geometry Get(string identifier)
        {
            if(RegisteredGeometries.TryGetValue(identifier, out var geometry))
            {
                return geometry;
            }
            throw new Exception($"Geometry of type {identifier} was not found!");
        }
    }
}
