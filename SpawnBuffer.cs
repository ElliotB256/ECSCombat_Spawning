// Author: Elliot Bentine, github.com/ElliotB256
using Unity.Entities;

namespace Spawning
{
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    public class SpawnBuffer : EntityCommandBufferSystem
    {
    }
}
