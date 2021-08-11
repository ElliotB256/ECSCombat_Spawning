// Author: Elliot Bentine, github.com/ElliotB256
using Spawning.Hookpoints;
using Unity.Entities;
using Unity.Transforms;

namespace Spawning.Mounting
{
    /// <summary>
    /// Mounts entities into hookpoints.
    /// </summary>
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    [UpdateAfter(typeof(SpawnBuffer))]
    [UpdateAfter(typeof(InitialiseHookpointBufferSystem))]
    [UpdateBefore(typeof(RemoveHookpointBuffersSystem))]
    [UpdateBefore(typeof(MountBuffer))]
    public class MountSystem : SystemBase
    {
        MountBuffer BufferSystem;
        EntityQuery Query;

        protected override void OnCreate()
        {
            BufferSystem = World.GetOrCreateSystem<MountBuffer>();
        }

        protected override void OnUpdate()
        {
            var buffer = BufferSystem.CreateCommandBuffer();
            var hookpointBuffers = GetBufferFromEntity<HookpointBufferElement>(true);

            Entities.ForEach(
                (in Mount mount, in Target target) =>
                {
                    if (mount.Type == Mount.Strategy.None)
                    {
                        var spawned = buffer.Instantiate(mount.Template);
                        buffer.SetComponent(spawned, new Translation());
                        buffer.SetComponent(spawned, new Rotation());
                        buffer.AddComponent(spawned, new LocalToParent());
                        buffer.AddComponent(spawned, new Parent { Value = target.Value });
                    }
                    else
                    {
                        var hookpoints = hookpointBuffers[target.Value];
                        for (int i = 0; i < hookpoints.Length; i++)
                        {
                            var hookpointEntity = hookpoints[i].Hookpoint;
                            var hookpoint = GetComponent<Hookpoint>(hookpointEntity);
                            if (hookpoint.Occupied)
                                continue;
                            if (hookpoint.Type != mount.Target)
                                continue;

                            // Spawn replacement
                            var spawned = buffer.Instantiate(mount.Template);
                            buffer.SetComponent(spawned, GetComponent<Translation>(hookpointEntity));
                            buffer.SetComponent(spawned, GetComponent<Rotation>(hookpointEntity));
                            buffer.AddComponent(spawned, new LocalToParent());
                            buffer.AddComponent(spawned, GetComponent<Parent>(hookpointEntity));
                            hookpoint.Occupied = true;
                            SetComponent(hookpointEntity, hookpoint);

                            if (mount.Type != Mount.Strategy.All)
                                break;
                        }
                    }
                }
                )
                .WithStoreEntityQueryInField(ref Query)
                .Run();

            buffer.DestroyEntity(Query);
        }
    }
}
