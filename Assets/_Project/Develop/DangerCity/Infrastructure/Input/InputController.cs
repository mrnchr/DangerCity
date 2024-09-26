using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DangerCity.Infrastructure.Input
{
  public class InputController : ITickable
  {
    private readonly InputData _inputData;
    private readonly PlayerInputActions _inputActions;
    private readonly PlayerInputActions.GameplayActions _gameplay;

    public InputController(InputData inputData, PlayerInputActions inputActions, PlayerInput input)
    {
      _inputData = inputData;
      _inputActions = inputActions;

      input.actions = _inputActions.asset;
      _gameplay = _inputActions.Gameplay;
    }
    
    public void Tick()
    {
     _inputData.Clear();
     
     _inputData.Movement = _gameplay.Movement.ReadValue<Vector2>();
     _inputData.Jump = _gameplay.Jump.WasPerformedThisFrame();
     _inputData.Interact = _gameplay.Interaction.WasPerformedThisFrame();
    }
  }
}