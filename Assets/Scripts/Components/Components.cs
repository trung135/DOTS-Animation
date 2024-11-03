using Unity.Entities;
using Unity.Mathematics;

namespace Clover
{
    public struct InputData : IComponentData
    {
        public float2 move;
    }

    public struct PlayerData : IComponentData
    {
        public float speed;
    }

    // Component để lưu chỉ số sprite hiện tại
    public struct SpriteIndex : IComponentData
    {
        public int Value; // Chỉ số của sprite hiện tại
    }

    // Component để lưu thời gian đã trôi qua
    public struct SpriteElapsedTime : IComponentData
    {
        public float Value; // Thời gian đã trôi qua
    }

    // Component để định nghĩa khoảng thời gian giữa các lần chuyển sprite
    public struct SpriteInterval : IComponentData
    {
        public float Value; // Khoảng thời gian để chuyển sang sprite tiếp theo
    }

    // Component để lưu thông tin sprite sheet
    public struct SpriteSheetInfo : IComponentData
    {
        public int Length; // Số lượng sprites trong sprite sheet
    }
}