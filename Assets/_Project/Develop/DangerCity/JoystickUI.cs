using UnityEngine;

namespace DangerCity
{
  public class JoystickUI : MonoBehaviour
  {
    private PlayerController _movement;

    private void Awake()
    {
      _movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void ActionBtn()
    {
      _movement.Joystick(0, 0, false, true);
    }

    public void JumpBtn()
    {
      _movement.Joystick(0, 0, true);
    }
  }
}