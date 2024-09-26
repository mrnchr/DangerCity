using DangerCity.Gameplay;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class MainCoin : MonoBehaviour
  {
    private GameModel _gameModel;

    [Inject]
    public void Construct(GameModel gameModel)
    {
      _gameModel = gameModel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        _gameModel.IsOpen = true;
    }
  }
}