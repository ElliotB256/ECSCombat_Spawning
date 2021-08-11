// Author: Elliot Bentine, github.com/ElliotB256
using Spawning.Hookpoints;
using Spawning.Mounting;
using Unity.Entities;

namespace Spawning.Refitting
{
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    [UpdateAfter(typeof(InitialiseHookpointBufferSystem))]
    [UpdateBefore(typeof(MountSystem))]
    public class RefitSystem : SystemBase
    {
        EntityQuery Query;
        MountBuffer BufferSystem;

        protected override void OnCreate()
        {
            BufferSystem = World.GetOrCreateSystem<MountBuffer>();
        }

        protected override void OnUpdate()
        {
            var buffer = BufferSystem.CreateCommandBuffer();
            var hookpointBuffers = GetBufferFromEntity<HookpointBufferElement>(true);

            Entities.ForEach(
                (in Refit refit, in Target target) =>
                {
                    var hookpoints = hookpointBuffers[target.Value];
                    for (int i = 0; i < hookpoints.Length; i++)
                    {
                        var hookpointEntity = hookpoints[i].Hookpoint;
                        var hookpoint = GetComponent<Hookpoint>(hookpointEntity);
                        if (hookpoint.Occupied)
                            continue;
                        if (hookpoint.Type != refit.Target)
                            continue;

                        hookpoint.Type = refit.Replacement;
                        SetComponent(hookpointEntity, hookpoint);
                        return;
                    }
                }
                )
                .WithStoreEntityQueryInField(ref Query)
                .Run();

            buffer.DestroyEntity(Query);
        }
    }
}
