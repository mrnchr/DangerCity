﻿using System;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
  public class HeroMover : IHeroProcessor, ITickable, IDisposable
  {
    private readonly IHeroController _controller;
    private readonly IExplicitInitializer _initializer;
    private readonly InputData _inputData;
    private readonly Rigidbody2D _rb;
    private readonly HeroConfig _config;

    public HeroMover(IHeroController controller,
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
      
      _controller.Model.IsWalk.Value = true;
    }

    public void Dispose()
    {
      _initializer.Remove(this);
    }

    public void Tick()
    {
      if (_controller.Model.CanMove && _controller.Model.IsWalk)
        Walk(_inputData.Movement.x);
    }

    private void Walk(float direction)
    {
      _rb.velocity = new Vector2(direction * _config.Speed, _rb.velocity.y);
      _controller.Model.IsMove.Value = direction != 0;

      if (direction != 0)
      {
        _controller.Model.BodyDirection.Value = Mathf.Sign(direction);
        _controller.View.transform.eulerAngles = new Vector3(0, direction > 0 ? 0 : 180, 0);
      }
    }
  }
}