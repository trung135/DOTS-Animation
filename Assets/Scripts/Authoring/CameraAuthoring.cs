using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CameraAuthoring : MonoBehaviour
{
    public float3 offset;
    private class CameraAuthoringBaker : Baker<CameraAuthoring>
    {
        public override void Bake(CameraAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var mainCamera = Camera.main;
            AddComponent<MainCameraTag>(entity);
            AddComponent(entity, new CameraRef
            {
                Value = mainCamera
            });
            AddComponent(entity, new CameraOffset
            {
                Value = authoring.offset
            });
        }
    }
}