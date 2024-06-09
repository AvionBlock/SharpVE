using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SharpVE.Chunks.Layers
{
    /// <summary>
    /// A shared pool of single blockstate layers.
    /// </summary>
    public class SharedLayeredChunk<T> : SingleLayeredChunk<T> where T : class
    {
        private static ConcurrentDictionary<Object, SharedLayeredChunk<T>?> sharedInstances = new ConcurrentDictionary<Object,SharedLayeredChunk<T>?>();

        private SharedLayeredChunk(SubChunk<T> subChunk, T blockState) : base(subChunk, blockState) { }

        /// <summary>
        /// Fills a layer in the shared subchunk.
        /// </summary>
        /// <param name="blockState"> The subchunk to associate the layer to. </param>
        /// <param name="localY"> The blockstate to set for the layer. </param>
        /// <param name="subChunk"> The y layer that the layer will be set to. </param>
        public override void Fill(SubChunk<T> subChunk, T blockState, int localY)
        {
            if(blockState != BlockState)
            {
                subChunk.SetLayer(GetOrAdd(subChunk, blockState), localY); //Already updates subchunk.
            }
        }

        /// <summary>
        /// Get's or adds a single blockstate layer.
        /// </summary>
        /// <param name="blockState"> The subchunk to associate the layer to. </param>
        /// <param name="blockState"> The blockstate to set for the layer. </param> 
        public static SharedLayeredChunk<T> GetOrAdd(SubChunk<T> subChunk, T blockState)
        {
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