using UnityEngine;
using UnityEngine.Serialization;

public class GameLogic : MonoBehaviour
{
  [FormerlySerializedAs("isOpen")]
  public bool IsOpen;
  
  [FormerlySerializedAs("isWin")]
  public bool IsWin;

  private void Awake()
  {
    IsOpen = false;
    IsWin = false;
  }
}