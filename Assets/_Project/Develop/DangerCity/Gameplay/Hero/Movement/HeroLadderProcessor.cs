using System;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
    public class HeroLadderProcessor : IHeroProcessor, IFixedTickable, ITickable, IDisposable
    {
        private readonly HeroConfig _config;
        private readonly IHeroController _controller;
        private readonly IExplicitInitializer _initializer;
        private readonly InputData _inputData;
        private readonly Rigidbody2D _rb;

        public HeroLadderProcessor(IHeroController controller,
            IExplicitInitializer initializer,
            IConfigProvider configProvider,
            InputData inputData)
        {
            _controller = controller;
            _initializer = initializer;
            _inputData = inputData;
            _rb = _controller.View.Rigidbody;
            _config = configProvider.Get<HeroConfig>();

            _initializer.Add(this);
        }

        public void Dispose()
        {
            _initializer.Remove(this);
        }

        public void FixedTick()
        {
            if (_controller.Model.CanMove && _controller.Model.IsLadder && _rb.velocity.y < 0)
            {
                _controller.Model.IsJump.Value = false;
                _rb.gravityScale = 0;
            }
        }

        public void Tick()
        {
            if (_controller.Model.CanMove
                && _controller.Model.IsLadder)
                OnLadder();
        }

        private void OnLadder()
        {
            Vector2 velocity = _inputData.Movement * _config.SpeedOnLadder;
            if (_controller.Model.IsJump)
                velocity.y = _rb.velocity.y;

            _rb.velocity = velocity;
        }
    }
}