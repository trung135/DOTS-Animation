using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Systems
{
    public partial struct SpawnSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Spawner>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var prefab = SystemAPI.GetSingleton<Spawner>().PrefabEntity;
            var entity = state.EntityManager.Instantiate(prefab);

            state.Enabled = false;
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}