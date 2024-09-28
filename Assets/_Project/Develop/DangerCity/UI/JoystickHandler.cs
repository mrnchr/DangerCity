using UnityEngine;
using Zenject;

namespace DangerCity.UI
{
  public class JoystickHandler : MonoBehaviour, ITickable
  {
    [SerializeField]
    private Joystick _joystick;

    private TickableManager _ticker;
    private JoystickModel _model;

    [Inject]
    public void Construct(JoystickModel model, TickableManager ticker)
    {
      _ticker = ticker;
      _model = model;
      _ticker.Add(this, -1);
    }

    public void Tick()
    {
      _model.Movement = _joystick.Direction;
    }

    private void OnDestroy()
    {
      _ticker.Remove(this);
    }

    private void Reset()
    {
      _joystick = GetComponent<Joystick>();
    }
  }
}