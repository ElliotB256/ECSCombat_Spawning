// Author: Elliot Bentine, github.com/ElliotB256
using Unity.Entities;

namespace Spawning.Hookpoints
{
    /// <summary>
    /// Deletes hookpoints and hookpoint buffers from spawned entities.
    /// </summary>
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    public class RemoveHookpointBuffersSystem : SystemBase
    {
        EntityQuery HookpointBufferQuery;

        protected override void OnCreate()
        {
            HookpointBufferQuery = EntityManager.CreateEntityQuery(ComponentType.ReadWrite<HookpointBufferElement>());
        }

        protected override void OnUpdate()
        {
            EntityManager.RemoveComponent<HookpointBufferElement>(HookpointBufferQuery);
        }
    }
}
