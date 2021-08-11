// Author: Elliot Bentine, github.com/ElliotB256
using Unity.Entities;
using Unity.Transforms;

namespace Spawning.Hookpoints
{
    /// <summary>
    /// Initialises the hookpoint buffer on newly spawned entities.
    /// </summary>
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    [UpdateAfter(typeof(SpawnBuffer))]
    public class InitialiseHookpointBufferSystem : SystemBase
    {
        EntityQuery Query;

        protected override void OnUpdate()
        {
            var hookpointBuffers = GetBufferFromEntity<HookpointBufferElement>(false);

            Entities
                .WithNone<Initialised>()
                .ForEach(
                (Entity entity, in Hookpoint hookpoint, in Parent parent) =>
                {
                    var root = parent.Value;
                    while (HasComponent<Parent>(root))
                        root = GetComponent<Parent>(root).Value;
                    var buffer = hookpointBuffers[root];
                    buffer.Add(new HookpointBufferElement { Hookpoint = entity });
                }
                )
                .WithStoreEntityQueryInField(ref Query)
                .Run();

            EntityManager.AddComponent<Initialised>(Query);
        }
    }
}
