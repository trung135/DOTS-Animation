using Clover;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

class PlayerAuthoring : MonoBehaviour
{
    public float speed;
    public float spriteInterval;
    public int spriteCount;
    public ushort assetID;
    public ushort animationID;
}

class PlayerBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MovementData 
        {
            Speed = authoring.speed 
        });
        AddComponent<InputData>(entity);
        AddComponent<StateData>(entity);
        AddComponent<DirectionData>(entity);
        AddComponent<SpriteIndex>(entity);
        AddComponent<SpriteElapsedTime>(entity);
        AddComponent(entity, new SpriteInterval
        {
            Value = authoring.spriteInterval
        });
        AddComponent(entity, new SpriteSheetInfo
        {
            Id = new SpriteSheetId(authoring.assetID, authoring.animationID),
            Length = authoring.spriteCount
        });
    }
}
