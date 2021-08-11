// Author: Elliot Bentine, github.com/ElliotB256
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Spawning.Modifiers
{
    [DisallowMultipleComponent]
    public class ModifierBufferElementAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public List<GameObject> Modifiers;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddBuffer<ModifierBufferElement>(entity);
            var buffer = dstManager.GetBuffer<ModifierBufferElement>(entity);
            for (int i = 0; i < Modifiers.Count; i++)
            {
                var modifier = conversionSystem.GetPrimaryEntity(Modifiers[i]);
                buffer.Add(new ModifierBufferElement
                {
                    Modifier = modifier
                });
            }
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.AddRange(Modifiers);
        }
    }
}