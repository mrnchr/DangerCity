using DangerCity.Gameplay;
using DangerCity.Gameplay.Hero;
using DangerCity.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class PlayerController : MonoBehaviour
  {
    public HeroModel HeroModel;

    private HeroInventory _inventory;

    [Inject]
    public void Construct(GameModel gameModel,
      InputData inputData,
      HeroInventory inventory,
      HeroModel heroModel)
    {
      HeroModel = heroModel;
      _inventory = inventory;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Coin") && !HeroModel.IsDie)
      {
        _inventory.Coins.Value++;
        Destroy(collision.gameObject);
      }
    }
  }
}