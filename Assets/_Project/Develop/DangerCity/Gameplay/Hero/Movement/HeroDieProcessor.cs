using System;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.LifeCycle;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
  public class HeroDieProcessor: IHeroProcessor, ITickable, IDisposable
  {
    private readonly IHeroController _controller;
    private readonly IExplicitInitializer _initializer;
    private readonly ITimerFactory _timers;
    private readonly HeroConfig _config;

    private Timer _deathDuration = 0;

    public HeroDieProcessor(IHeroController controller,
      IExplicitInitializer initializer,
      IConfigProvider configProvider,
      ITimerFactory timers)
    {
      _controller = controller;
      _initializer = initializer;
      _timers = timers;
      _config = configProvider.Get<HeroConfig>();

      _initializer.Add(this);

      _controller.Model.IsDie.OnChanged += Die;
    }

    private void Die()
    {
      if (_controller.Model.IsDie)
      {
        _controller.Model.CanMove.Value = false;
        _deathDuration = _timers.Create(_config.DeathDuration);
      }
    }

    public void Dispose()
    {
      _controller.Model.IsDie.OnChanged -= Die;
      _initializer.Remove(this);
    }

    public void Tick()
    {
      if (_controller.Model.IsDie && _deathDuration <= 0)
      {
        _controller.View.transform.position = _controller.View.StartPosition;
        _controller.Model.IsDie.Value = false;
        _controller.Model.CanMove.Value = true;
      }
    }
  }
}