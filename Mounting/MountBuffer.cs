// Author: Elliot Bentine, github.com/ElliotB256
using Unity.Entities;

namespace Spawning.Mounting
{
    /// <summary>
    /// Buffer that creates entities that are mounted into hookpoints.
    /// </summary>
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    public class MountBuffer : EntityCommandBufferSystem
    {
    }
}
