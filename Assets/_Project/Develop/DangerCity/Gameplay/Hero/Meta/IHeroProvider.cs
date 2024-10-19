namespace DangerCity.Gameplay.Hero.Meta
{
    public interface IHeroProvider
    {
        IHeroController HeroController { get; set; }
    }
}