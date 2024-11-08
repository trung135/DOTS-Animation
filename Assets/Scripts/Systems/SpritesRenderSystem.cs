using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using Clover.Systems;

namespace Systems
{
   
    [UpdateAfter(typeof(SpritesAnimateSystem))]
    public partial struct SpritesRenderSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<AnimationData>();
        }
        
        public void OnUpdate(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}