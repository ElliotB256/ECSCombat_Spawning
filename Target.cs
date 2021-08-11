// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning
{
    /// <summary>
    /// The target of an entity that changes spawning, for example a Modifier or Refit.
    /// </summary>
    [Serializable]
    public struct Target : IComponentData
    {
        public Entity Value;
    }
}
