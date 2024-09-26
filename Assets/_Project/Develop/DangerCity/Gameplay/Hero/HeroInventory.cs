using DangerCity.Infrastructure;

namespace DangerCity.Gameplay.Hero
{
  public class HeroInventory
  {
    public readonly CallbackValue<int> Coins = new CallbackValue<int>();
  }
}