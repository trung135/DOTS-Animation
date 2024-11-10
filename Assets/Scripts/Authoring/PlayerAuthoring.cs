using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new MoveData
            {
                Speed = authoring.moveSpeed
            });
            AddComponent<InputData>(entity);
            AddComponent<SpriteIndex>(entity);
        }
    }
}