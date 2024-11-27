using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Clover;

namespace Systems
{
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
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<InputData>, RefRO<MovementData>>())
            {
                transform.ValueRW.Position.x += input.ValueRO.Move.x * speed.ValueRO.Speed * SystemAPI.Time.DeltaTime;
                transform.ValueRW.Position.y += input.ValueRO.Move.y * speed.ValueRO.Speed * SystemAPI.Time.DeltaTime;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        
        }
    }
}
