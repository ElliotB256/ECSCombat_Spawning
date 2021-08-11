// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning.Hookpoints
{
    [Serializable]
    public struct Hookpoint : IComponentData
    {
        public HookpointType Type;
        public bool Occupied;
    }

    public enum HookpointType
    {
        SmallWeapon,
        LargeWeapon,
        SmallUtility,
        LargeUtility,
        Special
    }
}
