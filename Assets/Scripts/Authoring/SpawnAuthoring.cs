using Unity.Entities;
using UnityEngine;

public class SpawnAuthoring : MonoBehaviour
{
    public GameObject prefabGo;
    public SpriteRenderer spriteRenderer;

    public class SpawnerBaker : Baker<SpawnAuthoring>
    {
        public override void Bake(SpawnAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Spawner
            {
                PrefabEntity = GetEntity(authoring.prefabGo, TransformUsageFlags.Dynamic)
            });
            AddComponent(entity, new SpriteRendererData
            {
                spriteRef = authoring.spriteRenderer
            });
        }
    }
}

public struct Spawner : IComponentData
{
    public Entity PrefabEntity;
}

public struct SpriteRendererData : IComponentData
{
    public UnityObjectRef<SpriteRenderer> spriteRef;
}