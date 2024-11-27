using Unity.Burst;
using Unity.Entities;
using Clover;
using UnityEngine;

namespace Systems
{
    public partial struct SpritesAnimateSystem : ISystem
    {
        private EntityQuery _query;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _query = SystemAPI.QueryBuilder()
                .WithAllRW<SpriteIndex, SpriteElapsedTime>()
                .WithAll<SpriteInterval, SpriteSheetInfo>()
                .Build();

            state.RequireForUpdate(_query);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            var job = new AnimateSpriteJob
            {
                DeltaTime = deltaTime
            };

            state.Dependency = job.ScheduleParallel(_query, state.Dependency);
        }
        
        private partial struct AnimateSpriteJob : IJobEntity
        {
            public float DeltaTime;

            public void Execute(
                ref SpriteIndex spriteIndex,
                ref SpriteElapsedTime spriteElapsedTime,
                in SpriteInterval spriteInterval,
                in SpriteSheetInfo spriteSheetInfo
            )
            {
                spriteElapsedTime.Value += DeltaTime;

                if (spriteElapsedTime.Value >= spriteInterval.Value)
                {
                    spriteElapsedTime.Value = 0f; // Reset elapsed time
                    spriteIndex.Value = (spriteIndex.Value + 1) % spriteSheetInfo.Length; // Cập nhật chỉ số sprite
                }
            }
        }
    }
}