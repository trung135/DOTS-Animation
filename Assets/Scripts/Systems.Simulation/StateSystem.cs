using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Clover
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateAfter(typeof(DirectionSystem))]
    public partial struct StateSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            var query = SystemAPI.QueryBuilder()
                .WithAllRW<SpriteSheetInfo>()
                .WithAll<InputData, DirectionData, AssetData>()
                .Build();
            
            state.RequireForUpdate(query);
        }

        //[BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (spriteSheetInfo, input, direction, asset) in
                     SystemAPI.Query<RefRW<SpriteSheetInfo>, RefRO<InputData>, RefRO<DirectionData>, RefRO<AssetData>>())
            {
                var id = new AssetAnimDirectionId(spriteSheetInfo.ValueRO.Id.AssetId,
                    spriteSheetInfo.ValueRO.Id.AnimId, (ushort)direction.ValueRO.Value);
                if (SpriteSheetVault.TryGetAmountSprite(id, out var amount) == false)
                {
                    continue;
                }

                var inputData = input.ValueRO.Move;
                if (inputData is { x: 0, y: 0 })
                {
                    spriteSheetInfo.ValueRW.Id = new AssetAnimId(asset.ValueRO.Value, (int)State.Idle);
                }
                else
                {
                    spriteSheetInfo.ValueRW.Id = new AssetAnimId(asset.ValueRO.Value, (int)State.Run);
                }

                spriteSheetInfo.ValueRW.Length = amount;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}