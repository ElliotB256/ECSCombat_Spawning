// Author: Elliot Bentine, github.com/ElliotB256
using System;
using Unity.Entities;

namespace Spawning.Hookpoints
{
    /// <summary>
    /// Indicates an entities Hookpoints are initialised.
    /// </summary>
    [GenerateAuthoringComponent]
    [Serializable]
    public struct Initialised : IComponentData
    {
    }
}
