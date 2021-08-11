// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning.Modifiers
{
    [Serializable]
    public struct ModifierBufferElement : IBufferElementData
    {
        public Entity Modifier;
    }
}
