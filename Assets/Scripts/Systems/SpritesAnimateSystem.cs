using Systems;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Clover.Systems
{
    public struct AnimationData : IComponentData
    {
        public int CurrentFrameIndex;
        public float ElapsedTime;
        public float FrameTime;
        public int TotalFrames;
    }

    public partial struct SpritesAnimateSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            AnimationData animData = new AnimationData
            {
                CurrentFrameIndex = 0,
                ElapsedTime = 0f,
                FrameTime = 0.5f,
                TotalFrames = 6
            };
            
            state.EntityManager.CreateSingleton(animData, nameof(AnimationData));
        }

        public void OnUpdate(ref SystemState state)
        {
            var singleton = SystemAPI.GetSingletonRW<AnimationData>();
            var deltaTime = SystemAPI.Time.DeltaTime;
            var frameTime = singleton.ValueRO.FrameTime;
            var totalFrames = singleton.ValueRO.TotalFrames;
            singleton.ValueRW.ElapsedTime += deltaTime;
            if (singleton.ValueRW.ElapsedTime >= frameTime)
            {
                singleton.ValueRW.CurrentFrameIndex = (singleton.ValueRW.CurrentFrameIndex + 1) % totalFrames;
                singleton.ValueRW.ElapsedTime = 0f;
                //Debug.Log("Current Frame: " + singleton.ValueRW.CurrentFrameIndex);
            }
        }
    }
}