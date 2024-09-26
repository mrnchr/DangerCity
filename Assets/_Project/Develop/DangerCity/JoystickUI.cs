using DangerCity.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class JoystickUI : MonoBehaviour
  {
    private InputData _inputData;

    [Inject]
    public void Construct(InputData inputData)
    {
      _inputData = inputData;
    }

    public void ActionBtn()
    {
      _inputData.Interact = true;
    }

    public void JumpBtn()
    {
      _inputData.Jump = true;
    }
  }
}