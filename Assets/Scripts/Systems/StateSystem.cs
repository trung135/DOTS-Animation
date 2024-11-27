using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Clover
{
    public partial struct StateSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (spriteSheetInfo, input) in
                     SystemAPI.Query<RefRW<SpriteSheetInfo>, RefRO<InputData>>())
            {
                var inputData = input.ValueRO.Move;
                if (inputData is { x: 0, y: 0 })
                {
                    //statement.ValueRW.Value = (int)State.Idle;
                    spriteSheetInfo.ValueRW.Id = new SpriteSheetId(0, 1);
                }
                else
                {
                    //statement.ValueRW.Value = (int)State.Run;
                    spriteSheetInfo.ValueRW.Id = new SpriteSheetId(0, 2);
                }
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}