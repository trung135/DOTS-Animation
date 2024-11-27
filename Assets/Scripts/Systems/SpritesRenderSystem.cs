using Clover;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public partial struct SpritesRenderSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        //[BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (index, spriteSheetInfo, direction, entity) in
                     SystemAPI.Query<RefRO<SpriteIndex>, RefRO<SpriteSheetInfo>, RefRO<DirectionData>>()
                         .WithEntityAccess())
            {
                if (SpriteSheetVault.TryGetSheet(spriteSheetInfo.ValueRO.Id, out var animation) == false)
                {
                    continue;
                }

                var curDirection = direction.ValueRO.Value;
                var curIndex = index.ValueRO.Value;

                SpriteRenderer renderer = state.EntityManager.GetComponentObject<SpriteRenderer>(entity);
                renderer.sprite = animation.DirectionList.Span[curDirection].SpriteList.Span[curIndex];
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}