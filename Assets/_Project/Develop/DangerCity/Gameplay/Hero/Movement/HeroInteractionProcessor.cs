using System;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure.Input;
using DangerCity.Infrastructure.LifeCycle;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
    public class HeroInteractionProcessor : IHeroProcessor, ITickable, IDisposable
    {
        private readonly IHeroController _controller;
        private readonly IExplicitInitializer _initializer;
        private readonly InputData _inputData;

        public HeroInteractionProcessor(IHeroController controller,
            IExplicitInitializer initializer,
            InputData inputData)
        {
            _controller = controller;
            _initializer = initializer;
            _inputData = inputData;

            _initializer.Add(this);
        }

        public void Dispose()
        {
            _initializer.Remove(this);
        }

        public void Tick()
        {
            if (_controller.Model.CanMove && _inputData.Interact)
                _controller.Model.OnInteracted?.Invoke();
        }
    }
}