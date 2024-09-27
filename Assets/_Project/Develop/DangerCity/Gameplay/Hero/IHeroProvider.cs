namespace DangerCity.Gameplay.Hero
{
  public interface IHeroProvider
  {
    IHeroController HeroController { get; set; }
  }
}