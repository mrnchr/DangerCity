using System.Collections.Generic;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;

namespace DangerCity.Gameplay.Hero
{
  public interface IHeroController
  {
    TProcessor GetProcessor<TProcessor>() where TProcessor : IHeroProcessor;
    void AddProcessor(IHeroProcessor processor);
    void SetView(HeroView view);
    HeroModel Model { get; }
    HeroView View { get; }
    IEnumerable<TProcessor> GetProcessors<TProcessor>();
  }
}