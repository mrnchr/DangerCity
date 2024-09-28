using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Movement;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Environment
{
  [AddComponentMenu(ACC.Names.COIN_VIEW)]
  public class CoinView : MonoBehaviour
  {
    [SerializeField]
    private HeroDetector _heroDetector;

    private HeroInventory _inventory;

    [Inject]
    public void Construct(HeroInventory inventory)
    {
      _inventory = inventory;
      _heroDetector.OnHeroDetected += CatchSelf;
    }

    private void CatchSelf()
    {
      _inventory.Coins.Value++;
      Destroy(gameObject);
    }

    private void OnDestroy()
    {
      _heroDetector.OnHeroDetected -= CatchSelf;
    }

    private void Reset()
    {
      _heroDetector = GetComponent<HeroDetector>();
    }
  }
}