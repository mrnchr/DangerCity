using System;
using DangerCity.Gameplay.Hero;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.FlexibleCamera
{
    public class CameraController : ICameraController, IInitializable, ILateTickable, IDisposable
    {
        private readonly IHeroProvider _heroProvider;
        private readonly IExplicitInitializer _initializer;
        private IHeroController _heroController;
        private CameraView _view;

        public CameraController(IHeroProvider heroProvider, IExplicitInitializer initializer)
        {
            _heroProvider = heroProvider;
            _initializer = initializer;

            _initializer.Add(this);
        }

        public void SetView(CameraView view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _initializer.Remove(this);
        }

        public void Initialize()
        {
            _heroController = _heroProvider.HeroController;
        }

        public void LateTick()
        {
            if (_heroController != null)
            {
                Vector3 coordinate = _heroController.View.transform.position;
                coordinate.z = _view.transform.position.z;
                coordinate.x = Mathf.Clamp(coordinate.x, _view.Left, _view.Right);
                coordinate.y = Mathf.Clamp(coordinate.y, _view.Bottom, _view.Top);
                _view.transform.position = coordinate;
            }
        }
    }
}