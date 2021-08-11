// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning
{
    /// <summary>
    /// Entity spawns `Count` of the given `Template`.
    /// </summary>
    [Serializable]
    public struct Spawn : IComponentData
    {
        public Entity Template;
        public int Count;
    }
}
