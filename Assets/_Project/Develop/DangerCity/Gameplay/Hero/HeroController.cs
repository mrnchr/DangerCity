using System.Collections.Generic;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;

namespace DangerCity.Gameplay.Hero
{
  public class HeroController : IHeroController
  {
    private readonly List<IHeroProcessor> _heroProcessors = new List<IHeroProcessor>();
    private readonly HeroModel _model;
    private HeroView _view;

    public HeroModel Model => _model;
    public HeroView View => _view;

    public HeroController(IHeroProvider heroProvider, HeroModel model)
    {
      _model = model;
      heroProvider.HeroController = this;
    }

    public void SetView(HeroView view)
    {
      _view = view;
    }

    public TProcessor GetProcessor<TProcessor>() where TProcessor : IHeroProcessor
    {
      return (TProcessor)_heroProcessors.Find(x => x is TProcessor);
    }

    public IEnumerable<TProcessor> GetProcessors<TProcessor>()
    {
      foreach (IHeroProcessor heroProcessor in _heroProcessors)
      {
        if (heroProcessor is TProcessor processor)
          yield return processor;
      }
    }

    public void AddProcessor(IHeroProcessor processor)
    {
      _heroProcessors.Add(processor);
    }
  }
}