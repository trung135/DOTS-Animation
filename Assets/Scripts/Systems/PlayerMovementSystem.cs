using Clover;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

partial struct PlayerMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, input, speed) in 
            SystemAPI.Query<RefRW<LocalTransform>, RefRO<InputData>, RefRO<PlayerData>>())
        {
            transform.ValueRW.Position.x += input.ValueRO.move.x * speed.ValueRO.speed * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position.y += input.ValueRO.move.y * speed.ValueRO.speed * SystemAPI.Time.DeltaTime;
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
