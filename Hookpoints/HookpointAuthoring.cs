// Author: Elliot Bentine, github.com/ElliotB256
using Spawning.Hookpoints;
using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class HookpointAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public HookpointType Type;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Hookpoint { Occupied = false, Type = Type });
    }
}
