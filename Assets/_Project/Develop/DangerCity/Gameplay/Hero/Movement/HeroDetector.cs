using System;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
    [AddComponentMenu(ACC.Names.HERO_DETECTOR)]
    public class HeroDetector : MonoBehaviour, IInitializable
    {
        private IHeroProvider _heroProvider;
        private HeroView _heroView;

        public event Action OnHeroDetected;

        public event Action OnHeroLost;

        [Inject]
        public void Construct(IHeroProvider heroProvider, IExplicitInitializer initializer)
        {
            _heroProvider = heroProvider;
            initializer.Add(this);
        }

        public void Initialize()
        {
            _heroView = _heroProvider.HeroController?.View;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CheckDetectHero(other.collider);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            CheckLostHero(other.collider);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckDetectHero(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            CheckLostHero(collision);
        }

        private void CheckDetectHero(Collider2D collision)
        {
            if (IsHeroCollision(collision))
                OnHeroDetected?.Invoke();
        }

        private void CheckLostHero(Collider2D collision)
        {
            if (IsHeroCollision(collision))
                OnHeroLost?.Invoke();
        }

        private bool IsHeroCollision(Collider2D collision)
        {
            if (collision.gameObject == gameObject)
                throw new ArgumentException("HeroDetector can't detect itself");

            return _heroView && _heroView.Rigidbody == collision.attachedRigidbody;
        }
    }
}