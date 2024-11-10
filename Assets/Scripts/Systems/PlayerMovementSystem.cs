using Clover;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Clover
{
    partial struct PlayerMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<InputData>();
            state.RequireForUpdate<MoveData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, input, speed) in
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<InputData>, RefRO<MoveData>>())
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
