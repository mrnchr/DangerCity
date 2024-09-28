namespace DangerCity.Gameplay.Hero.Meta
{
  public interface IHeroProcessorFactory
  {
    TProcessor Create<TProcessor>() where TProcessor : class, IHeroProcessor;
  }
}