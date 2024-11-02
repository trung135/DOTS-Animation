using Clover;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

internal partial class InputSystem : SystemBase
{
    private InputManager _inputManager;

    protected override void OnCreate()
    {
        _inputManager = new InputManager();
        _inputManager.Enable();
    }

    protected override void OnUpdate()
    {
        foreach (var input in
            SystemAPI.Query<RefRW<InputData>>())
        {
            input.ValueRW.move = _inputManager.Player.Move.ReadValue<Vector2>();
        }
    }

    protected override void OnDestroy()
    {
        _inputManager.Disable();
    }
}
