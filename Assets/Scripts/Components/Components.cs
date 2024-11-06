using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct PlayerData : IComponentData
{
    public float speed;
}

public struct InputData : IComponentData
{
    public float2 move;
}

public struct NativeSpriteSheetVault : IComponentData
{
    public NativeArray<SpriteSheetId> uniqueIdArray;
    
}