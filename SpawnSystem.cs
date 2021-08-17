// Author: Elliot Bentine, github.com/ElliotB256
using Spawning.Hookpoints;
using Spawning.Modifiers;
using Unity.Entities;
using Unity.Transforms;

namespace Spawning
{
    /// <summary>
    /// Spawns entities and copies modifiers to each spawned entity.
    /// 
    /// A spawn entity consists of a `Spawn` component, which defines the number and base template to spawn,
    /// and a buffer of modifiers. The modifiers are each applied to the spawned entities.
    /// 
    /// The spawning entity is destroyed after.
    /// </summary>
    [UpdateInGroup(typeof(SpawnSystemGroup))]
    [UpdateBefore(typeof(SpawnBuffer))]
    public class SpawnSystem : SystemBase
    {
        SpawnBuffer BufferSystem;
        EntityQuery Query;

        protected override void OnCreate()
        {
            BufferSystem = World.GetOrCreateSystem<SpawnBuffer>();
        }

        protected override void OnUpdate()
        {
            var buffer = BufferSystem.CreateCommandBuffer();
            var modifierBuffers = GetBufferFromEntity<ModifierBufferElement>(true);

            Dependency = Entities.ForEach(
                (DynamicBuffer<ModifierBufferElement> modifiers, in Spawn spawn, in Translation translation) =>
                {
                    for (int i = 0; i < spawn.Count; i++)
                    {
                        // Spawn the desired entity
                        var spawnedEntity = buffer.Instantiate(spawn.Template);
                        buffer.SetComponent(spawnedEntity, translation);
                        buffer.AddBuffer<HookpointBufferElement>(spawnedEntity);

                        // Copy each modifier to the newly spawned entity.
                        for (int j = 0; j < modifiers.Length; j++)
                        {
                            var element = modifiers[j];
                            var modifier = buffer.Instantiate(element.Modifier);
                            buffer.AddComponent<ModifierInstance>(modifier);
                            buffer.AddComponent(modifier, new Target { Value = spawnedEntity });
                        }
                    }

                }
                )
                .WithStoreEntityQueryInField(ref Query)
                .Schedule(Dependency);

            buffer.DestroyEntity(Query);
            BufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}
