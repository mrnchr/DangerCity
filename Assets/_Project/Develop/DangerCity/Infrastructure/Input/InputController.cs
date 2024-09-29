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
    private readonly PlayerInputActions.UIActions _ui;

    public InputController(InputData inputData, PlayerInputActions inputActions, PlayerInput input)
    {
      _inputData = inputData;
      _inputActions = inputActions;

      input.actions = _inputActions.asset;
      _gameplay = _inputActions.Gameplay;
      _ui = _inputActions.UI;
      _ui.Enable();
    }
    
    public void Tick()
    {
     _inputData.Clear();
     
     _inputData.Movement = _gameplay.Movement.ReadValue<Vector2>();
     _inputData.Jump = _gameplay.Jump.WasPerformedThisFrame();
     _inputData.Interact = _gameplay.Interaction.WasPerformedThisFrame();
     _inputData.Pause = _ui.Pause.WasPerformedThisFrame();
    }
  }
}