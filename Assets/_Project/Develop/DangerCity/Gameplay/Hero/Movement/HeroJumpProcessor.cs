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
    public class HeroJumpProcessor : IHeroProcessor, ITickable, IDisposable
    {
        private readonly HeroConfig _config;
        private readonly IHeroController _controller;
        private readonly IExplicitInitializer _initializer;
        private readonly InputData _inputData;
        private readonly Rigidbody2D _rb;

        public HeroJumpProcessor(IHeroController controller,
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

            _controller.Model.OnGround.OnChanged += FinishJump;
        }

        public void Dispose()
        {
            _controller.Model.OnGround.OnChanged -= FinishJump;
            _initializer.Remove(this);
        }

        public void Tick()
        {
            if (_controller.Model.CanMove
                && _inputData.Jump
                && !_controller.Model.IsJump
                && (_controller.Model.OnGround || _controller.Model.IsLadder))
                Jump();
        }

        private void Jump()
        {
            _rb.gravityScale = 1;
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * _config.JumpForce, ForceMode2D.Impulse);
            _controller.Model.IsJump.Value = true;
        }

        private void FinishJump()
        {
            if (_controller.Model.OnGround)
                _controller.Model.IsJump.Value = false;
        }
    }
}