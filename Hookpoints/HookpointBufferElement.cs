// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning.Hookpoints
{
    /// <summary>
    /// Stores a reference to all Hookpoints on the Entity.
    /// </summary>
    [GenerateAuthoringComponent]
    [Serializable]
    public struct HookpointBufferElement : IBufferElementData
    {
        public Entity Hookpoint;
    }
}
