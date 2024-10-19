using System;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.LifeCycle;
using DangerCity.Infrastructure.Physics;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
    public class CheckGroundProcessor : IHeroProcessor, IFixedTickable, IDisposable
    {
        private readonly IHeroController _controller;
        private readonly ContactFilter2D _filter;
        private readonly Transform _groundChecker;
        private readonly RaycastHit2D[] _hits;
        private readonly IExplicitInitializer _initializer;
        private readonly PhysicsConfig _physics;

        public CheckGroundProcessor(IHeroController controller,
            IExplicitInitializer initializer,
            IConfigProvider configProvider)
        {
            _controller = controller;
            _initializer = initializer;


            _groundChecker = _controller.View.GroundChecker;
            _physics = configProvider.Get<PhysicsConfig>();

            _hits = new RaycastHit2D[5];
            _filter = new ContactFilter2D
            {
                useLayerMask = true,
                layerMask = _physics.GroundMask,
                useTriggers = false
            };

            _initializer.Add(this);
        }

        public void Dispose()
        {
            _initializer.Remove(this);
        }

        public void FixedTick()
        {
            _controller.Model.OnGround.Value = 0 < Physics2D.CircleCast(_groundChecker.position,
                _physics.AcceptableGroundDistance, Vector2.zero, _filter, _hits);
        }
    }
}