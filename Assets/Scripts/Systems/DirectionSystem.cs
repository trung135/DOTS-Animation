using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Clover
{
    public partial struct DirectionSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (direction, input) in
                     SystemAPI.Query<RefRW<DirectionData>, RefRO<InputData>>())
            {
                var inputData = input.ValueRO.Move;
                if (inputData is not {x:0, y:0})
                    direction.ValueRW.Value = (int)GetDirection(inputData);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
        
        public Direction GetDirection(float2 vector)
        {
            // Tính góc theo radian bằng atan2
            float angle = math.atan2(vector.y, vector.x);

            // Chuyển đổi góc từ radian sang độ và đưa vào khoảng [0, 360)
            float angleInDegrees = math.degrees(angle);
            if (angleInDegrees < 0) angleInDegrees += 360;

            switch (angleInDegrees)
            {
                // Xác định hướng dựa trên góc
                case > 0f and < 90f:
                    return Direction.NorthEast;
                case 90f:
                    return Direction.North;
                case > 90f and < 180f:
                    return Direction.NorthWest;
                case 180f:
                    return Direction.West;
                case > 180f and < 270f:
                    return Direction.SouthWest;
                case 270f:
                    return Direction.South;
                case > 270f:
                    return Direction.SouthEast;
                // angleInDegrees = 0
                default:
                    return Direction.East;
            }
        }
    }
}