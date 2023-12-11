using SharpVE.Worlds.Chunks;
using SharpVE.Blocks;
using SharpVE.Registries;
using Silk.NET.Maths;

namespace SharpVE.WorldSpace
{
    public class World
    {
        public List<ChunkColumn> Chunks;
        public BlockRegistry BlockRegistry;

        public World(BlockRegistry registry)
        {
            Chunks = new List<ChunkColumn>();
            BlockRegistry = registry;
        }

        public BlockState? GetBlock(Vector3D<int> globalPosition)
        {
            foreach (var chunk in Chunks)
            {
                //Again. vector2D.Y is the Z position
                if (chunk.Position.X == Math.Floor((float)globalPosition.X / ChunkColumn.SIZE) && chunk.Position.Y == Math.Floor((float)globalPosition.Z / ChunkColumn.SIZE))
                {
                    //Convert global to local position.
                    var x = globalPosition.X % ChunkColumn.SIZE;
                    if (x < 0)
                    {
                        x += ChunkColumn.SIZE;
                    }

                    var z = globalPosition.Z % ChunkColumn.SIZE;
                    if (z < 0)
                    {
                        z += ChunkColumn.SIZE;
                    }

                    globalPosition.X = x;
                    globalPosition.Y = globalPosition.Y - ChunkColumn.MINY;
                    globalPosition.Z = z;

                    return chunk.GetBlock(globalPosition);
                }
            }
            return null;
        }

        public void SetBlock(Vector3D<int> globalPosition, BlockState block)
        {
            foreach (var chunk in Chunks)
            {
                //Again. vector2i.Y is the Z position
                if (chunk.Position.X == Math.Floor((float)globalPosition.X / ChunkColumn.SIZE) && chunk.Position.Y == Math.Floor((float)globalPosition.Z / ChunkColumn.SIZE))
                {
                    //Convert global to local position.
                    var x = globalPosition.X % ChunkColumn.SIZE;
                    if (x < 0)
                    {
                        x += ChunkColumn.SIZE;
                    }

                    var z = globalPosition.Z % ChunkColumn.SIZE;
                    if (z < 0)
                    {
                        z += ChunkColumn.SIZE;
                    }

                    globalPosition.X = x;
                    globalPosition.Y = globalPosition.Y - ChunkColumn.MINY;
                    globalPosition.Z = z;

                    chunk.SetBlock(globalPosition, block);
                }
            }
        }
    }
}
