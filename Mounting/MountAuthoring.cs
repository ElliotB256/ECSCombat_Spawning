// Author: Elliot Bentine, github.com/ElliotB256
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Spawning.Mounting;
using Spawning.Hookpoints;

[DisallowMultipleComponent]
public class MountAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject Template;
    public HookpointType Target;
    public Mount.Strategy Type;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var prefab = conversionSystem.GetPrimaryEntity(Template);
        dstManager.AddComponentData(entity, new Mount { Target = Target, Template = prefab, Type = Type });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(Template);
    }
}
