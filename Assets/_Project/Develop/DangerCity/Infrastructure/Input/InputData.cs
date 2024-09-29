using UnityEngine;

namespace DangerCity.Infrastructure.Input
{
  public class InputData
  {
    public Vector2 Movement;
    public bool Jump;
    public bool Interact;
    public bool Pause;

    public void Clear()
    {
      Movement = Vector2.zero;
      Jump = false;
      Interact = false;
    }
  }
}