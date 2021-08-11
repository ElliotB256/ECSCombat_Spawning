// Author: Elliot Bentine, github.com/ElliotB256
using Spawning.Hookpoints;
using System;
using Unity.Entities;

namespace Spawning.Refitting
{
    /// <summary>
    /// Indicates that this entity is a Refit.
    /// 
    /// A Refit changes a hookpoint of type `Replacement` to the type `Target`.
    /// </summary>
    [Serializable]
    public struct Refit : IComponentData
    {
        public HookpointType Replacement;
        public HookpointType Target;
    }
}
