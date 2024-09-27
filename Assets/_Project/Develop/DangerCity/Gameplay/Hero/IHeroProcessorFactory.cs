namespace DangerCity.Gameplay.Hero
{
  public interface IHeroProcessorFactory
  {
    TProcessor Create<TProcessor>() where TProcessor : class, IHeroProcessor;
  }
}