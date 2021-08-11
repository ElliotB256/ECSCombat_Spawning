// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning.Modifiers
{
    /// <summary>
    /// Indicates that this entity is a modifier - something that will change a `Spawn`.
    /// </summary>
    [GenerateAuthoringComponent]
    [Serializable]
    public struct Modifier : IComponentData
    {
    }
}
