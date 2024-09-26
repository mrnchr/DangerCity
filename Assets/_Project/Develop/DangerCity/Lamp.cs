using DangerCity.Gameplay;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Lamp : MonoBehaviour
  {
    public Color Green;
    private SpriteRenderer _spriteRenderer;
    private GameModel _gameModel;

    [Inject]
    public void Construct(GameModel gameModel)
    {
      _gameModel = gameModel;
    }

    private void Awake()
    {
      _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
      if (_gameModel.IsOpen)
        _spriteRenderer.color = Green;
    }
  }
}