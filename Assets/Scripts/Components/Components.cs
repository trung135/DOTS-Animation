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