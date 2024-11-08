using Clover.Systems;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [UpdateAfter(typeof(SpritesAnimateSystem))]
    public partial struct RenderSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }
        
        public void OnUpdate(ref SystemState state)
        {
            // foreach (var (anim, spriterenderer) in SystemAPI.Query<AnimationData, RefRW<SpriteRendererRef>>())
            // {
            //     var index = anim.CurrentFrameIndex;
            //     var sprite = SpriteAuthoring.Sprites[index];
            //     spriterenderer.ValueRW.Value.Value.sprite = sprite;
            // }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}