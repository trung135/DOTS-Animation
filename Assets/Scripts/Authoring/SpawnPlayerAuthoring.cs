using Unity.Entities;
using UnityEngine;

public class SpawnPlayerAuthoring : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int playerAmount;
    private class SpawnPlayerAuthoringBaker : Baker<SpawnPlayerAuthoring>
    {
        public override void Bake(SpawnPlayerAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.None);
            AddComponent(entity, new SpriteSpawnInfo
            {
                Amount = authoring.playerAmount
            });

            GetEntity(authoring.playerPrefab, TransformUsageFlags.Dynamic);
        }
    }
}