using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Clover
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateAfter(typeof(PlayerMovementSystem))]
    public partial struct CameraFollowSystem : ISystem
    {
        private EntityQuery _cameraQuery;
        private EntityQuery _playerQuery;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _cameraQuery = SystemAPI.QueryBuilder()
                .WithAll<MainCameraTag>()
                .Build();
            _playerQuery = SystemAPI.QueryBuilder()
                .WithAll<PlayerTag>()
                .Build();
            
            state.RequireForUpdate(_cameraQuery);
            state.RequireForUpdate(_playerQuery);
        }

        //[BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            Entity playerEntity = _playerQuery.GetSingletonEntity();
            LocalTransform playerTransform = SystemAPI.GetComponent<LocalTransform>(playerEntity);
            
            Entity cameraEntity = _cameraQuery.GetSingletonEntity();
            var cameraTransform = SystemAPI.GetComponentRW<LocalTransform>(cameraEntity);
            
            float3 cameraOffset = SystemAPI.GetComponent<CameraOffset>(cameraEntity).Value;
            
            Camera camera = SystemAPI.GetComponent<CameraRef>(cameraEntity).Value.Value;
            if (camera)
            {
                cameraTransform.ValueRW.Position = math.lerp(
                    cameraTransform.ValueRO.Position, 
                    playerTransform.Position + cameraOffset,
                    SystemAPI.Time.DeltaTime * 5f // Tốc độ smooth
                );
                
                // Sync Main Camera GameObject
                camera.transform.position = cameraTransform.ValueRO.Position;
            }
        }
    }
}