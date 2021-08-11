// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Spawning.Hookpoints;
using Unity.Entities;

namespace Spawning.Mounting
{
    /// <summary>
    /// A `Mount` fills empty `Target` hookpoints with the given entity Template.
    /// </summary>
    [Serializable]
    public struct Mount : IComponentData
    {
        public Entity Template;
        public HookpointType Target;

        public enum Strategy
        {
            All,
            First,
            None
        }

        public Strategy Type;
    }
}
