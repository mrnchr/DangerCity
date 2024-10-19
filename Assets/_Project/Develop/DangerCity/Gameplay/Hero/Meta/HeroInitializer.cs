using DangerCity.Gameplay.Hero.Movement;
using Zenject;

namespace DangerCity.Gameplay.Hero.Meta
{
    public class HeroInitializer : IInitializable
    {
        private readonly IHeroProcessorFactory _factory;
        private readonly IHeroProvider _heroProvider;

        public HeroInitializer(IHeroProvider heroProvider, IHeroProcessorFactory factory)
        {
            _heroProvider = heroProvider;
            _factory = factory;
        }

        public void Initialize()
        {
            if (_heroProvider.HeroController != null)
            {
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroAnimator>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroStartProcessor>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroMoveProcessor>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroJumpProcessor>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<CheckGroundProcessor>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroLadderProcessor>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroDieProcessor>());
                _heroProvider.HeroController.AddProcessor(_factory.Create<HeroInteractionProcessor>());

                foreach (IInitializableProcessor processor in _heroProvider.HeroController
                    .GetProcessors<IInitializableProcessor>())
                {
                    processor.Initialize();
                }
            }
        }
    }
}