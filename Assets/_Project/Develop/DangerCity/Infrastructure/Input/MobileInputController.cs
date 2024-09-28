using DangerCity.UI;
using DangerCity.UI.Buttons;
using Zenject;

namespace DangerCity.Infrastructure.Input
{
  public class MobileInputController : ITickable
  {
    private readonly InputData _inputData;
    private readonly InteractionButtonModel _interactionBtn;
    private readonly JumpButtonModel _jumpBtn;
    private readonly MenuButtonModel _menuBtn;
    private readonly JoystickModel _joystick;

    public MobileInputController(InputData inputData,
      InteractionButtonModel interactionBtn,
      JumpButtonModel jumpBtn,
      MenuButtonModel menuBtn,
      JoystickModel joystick)
    {
      _inputData = inputData;
      _interactionBtn = interactionBtn;
      _jumpBtn = jumpBtn;
      _menuBtn = menuBtn;
      _joystick = joystick;
    }
    
    public void Tick()
    {
      _inputData.Clear();
     
      _inputData.Movement = _joystick.Movement;
      _inputData.Jump = _jumpBtn.WasPerformedThisFrame;
      _inputData.Interact = _interactionBtn.WasPerformedThisFrame;
      _inputData.Menu = _menuBtn.WasPerformedThisFrame;
    }
  }
}