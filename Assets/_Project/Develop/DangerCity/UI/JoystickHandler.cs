using UnityEngine;
using Zenject;

namespace DangerCity.UI
{
    public class JoystickHandler : MonoBehaviour, ITickable
    {
        [SerializeField]
        private Joystick _joystick;

        private JoystickModel _model;

        private TickableManager _ticker;

        private void Reset()
        {
            _joystick = GetComponent<Joystick>();
        }

        private void OnDestroy()
        {
            _ticker.Remove(this);
        }

        public void Tick()
        {
            _model.Movement = _joystick.Direction;
        }

        [Inject]
        public void Construct(JoystickModel model, TickableManager ticker)
        {
            _ticker = ticker;
            _model = model;
            _ticker.Add(this, -1);
        }
    }
}