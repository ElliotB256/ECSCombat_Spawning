// Author: Elliot Bentine, github.com/ElliotB256
using Spawning.Hookpoints;
using Spawning.Refitting;
using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class RefitAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public HookpointType Target;
    public HookpointType Replacement;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Refit { Target = Target, Replacement = Replacement });
    }
}
