using System;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;

namespace DangerCity.Gameplay.Hero.Movement
{
    public class HeroAnimator : IHeroProcessor, IDisposable
    {
        private static readonly int _die = Animator.StringToHash("Die");
        private static readonly int _isJump = Animator.StringToHash("IsJump");
        private static readonly int _isRun = Animator.StringToHash("IsRun");

        private readonly IHeroController _controller;
        private readonly Animator _animator;

        public HeroAnimator(IHeroController controller, IExplicitInitializer initializer)
        {
            _controller = controller;
            _animator = _controller.View.Animator;

            initializer.Add(this);

            _controller.Model.IsJump.OnChanged += AnimateJump;
            _controller.Model.OnGround.OnChanged += AnimateJump;
            _controller.Model.IsLadder.OnChanged += AnimateJump;
            _controller.Model.IsDie.OnChanged += AnimateDie;
            _controller.Model.IsMove.OnChanged += AnimateRun;
        }

        public void Dispose()
        {
            _controller.Model.IsJump.OnChanged -= AnimateJump;
            _controller.Model.OnGround.OnChanged -= AnimateJump;
            _controller.Model.IsLadder.OnChanged -= AnimateJump;
            _controller.Model.IsDie.OnChanged -= AnimateDie;
            _controller.Model.IsMove.OnChanged -= AnimateRun;
        }

        private void AnimateRun()
        {
            _animator.SetBool(_isRun, _controller.Model.IsMove);
        }

        private void AnimateDie()
        {
            if (_controller.Model.IsDie)
                _animator.SetTrigger(_die);
        }

        private void AnimateJump()
        {
            _animator.SetBool(_isJump,
                _controller.Model.IsJump || !_controller.Model.OnGround || _controller.Model.IsLadder);
        }
    }
}