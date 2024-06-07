using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SharpVE.Chunks.Layers
{
        /// <summary>
        /// A shared pool of single blockstate layers.
        /// </summary>
    public class SharedLayeredChunk<T> : SingleLayeredChunk<T>
    {
        private static ConcurrentDictionary<Object, SharedLayeredChunk<T>?> sharedInstances = new ConcurrentDictionary<Object,SharedLayeredChunk<T>?>();

        private SharedLayeredChunk(SubChunk<T> subChunk, T blockState) : base(subChunk, blockState) { }

        /// <summary>
        /// Fills a layer in the shared subchunk.
        /// </summary>
        public void Fill(SubChunk<T> subChunk, int localY, T blockState)
        {
            if(!EqualityComparer<T>.Default.Equals(blockState, BlockState))
            {
                subChunk.SetLayer(GetOrAdd(subChunk, blockState), localY);
            }
        }

        /// <summary>
        /// Get's or adds a single blockstate layer.
        /// </summary>
        public static SharedLayeredChunk<T> GetOrAdd(SubChunk<T> subChunk, T blockState)
        {
            if(blockState == null) throw new ArgumentNullException(nameof(blockState));

            var shared = sharedInstances.GetValueOrDefault(blockState);
            if(shared == null)
            {
                shared = new SharedLayeredChunk<T>(subChunk, blockState);
                sharedInstances.TryAdd(blockState, shared);
            }
            return shared;
        }
    }
}