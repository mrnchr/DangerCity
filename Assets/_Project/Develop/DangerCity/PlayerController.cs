using DangerCity.Gameplay;
using DangerCity.Gameplay.Hero;
using DangerCity.Infrastructure.Input;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DangerCity
{
  public class PlayerController : MonoBehaviour
  {
    public HeroModel HeroModel;

    private GameModel _gameModel;
    private InputData _inputData;
    private HeroInventory _inventory;

    [Inject]
    public void Construct(GameModel gameModel,
      InputData inputData,
      HeroInventory inventory,
      HeroModel heroModel)
    {
      HeroModel = heroModel;
      _inventory = inventory;
      _inputData = inputData;
      _gameModel = gameModel;
    }

    private void Update()
    {
      Joystick(_inputData.Interact);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Coin") && !HeroModel.IsDie)
      {
        _inventory.Coins.Value++;
        Destroy(collision.gameObject);
      }
    }

    private void Joystick(bool action = false)
    {
      if (action)
      {
        if (HeroModel.CanTeleport)
          transform.position = HeroModel.TeleportPosition;

        if (HeroModel.IsExit)
        {
          _gameModel.IsWin.Value = true;
          int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
          if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextBuildIndex);
        }
      }
    }
  }
}