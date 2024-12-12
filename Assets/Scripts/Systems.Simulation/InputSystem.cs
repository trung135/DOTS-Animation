using Unity.Entities;
using UnityEngine;

namespace Clover
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    internal partial class InputSystem : SystemBase
    {
        private InputManager _inputManager;

        protected override void OnCreate()
        {
            RequireForUpdate<InputData>();
            
            _inputManager = new InputManager();
            _inputManager.Enable();
        }

        protected override void OnUpdate()
        {
            foreach (var input in
                     SystemAPI.Query<RefRW<InputData>>())
            {
                input.ValueRW.Move = _inputManager.Player.Move.ReadValue<Vector2>();
            }
        }

        protected override void OnDestroy()
        {
            _inputManager.Disable();
        }
    }
}
