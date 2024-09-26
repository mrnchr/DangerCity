using UnityEngine;

namespace DangerCity
{
  public class MainCoin : MonoBehaviour
  {
    private GameLogic _gameLogic;

    private void Awake()
    {
      _gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        _gameLogic.IsOpen = true;
    }
  }
}