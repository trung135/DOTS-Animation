using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
public struct InputData : IComponentData
{
    public float2 Move;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct SpriteIndex : IComponentData
{
    public int Value;
}

public struct NativeSpriteSheetVault : IComponentData
{
    public NativeArray<SpriteSheetId> uniqueIdArray;
    
}