using System;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero
{
  public class HeroAnimator : IHeroAnimator, ITickable, IDisposable
  {
    private static readonly int _die = Animator.StringToHash("Die");
    private static readonly int _isJump = Animator.StringToHash("IsJump");
    private static readonly int _isRun = Animator.StringToHash("IsRun");

    private readonly HeroModel _heroModel;
    private readonly IExplicitInitializer _initializer;
    private Animator _animator;

    public HeroAnimator(HeroModel heroModel, IExplicitInitializer initializer)
    {
      _heroModel = heroModel;
      _initializer = initializer;
      _initializer.Add(this);

      _heroModel.IsJump.OnChanged += AnimateJump;
      _heroModel.IsLadder.OnChanged += AnimateJump;
      _heroModel.IsDie.OnChanged += AnimateDie;
      _heroModel.IsMove.OnChanged += AnimateRun;
    }

    private void AnimateRun()
    {
      _animator.SetBool(_isRun, _heroModel.IsMove);
    }

    private void AnimateDie()
    {
      if (_heroModel.IsDie)
        _animator.SetTrigger(_die);
    }

    private void AnimateJump()
    {
      _animator.SetBool(_isJump, _heroModel.IsJump || _heroModel.IsLadder);
    }

    public void Dispose()
    {
      _initializer.Remove(this);
    }

    public void SetAnimator(Animator animator)
    {
      _animator = animator;
    }

    public void Tick()
    {
    }
  }
}