// Author: Elliot Bentine, github.com/ElliotB256
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Spawning;

[DisallowMultipleComponent]
public class SpawnAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject Template;
    public int Count;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var prefab = conversionSystem.GetPrimaryEntity(Template);
        dstManager.AddComponentData(entity, new Spawn { Template = prefab, Count = Count });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(Template);
    }
}
