using Zenject;

namespace DangerCity.Gameplay.Hero.Meta
{
  public class HeroProcessorFactory : IHeroProcessorFactory
  {
    private readonly IInstantiator _instantiator;

    public HeroProcessorFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public TProcessor Create<TProcessor>() where TProcessor : class, IHeroProcessor
    {
      return _instantiator.Instantiate<TProcessor>();
    }
  }
}