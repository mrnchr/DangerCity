using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Gameplay.Hero.Movement;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Environment
{
    [AddComponentMenu(ACC.Names.TELEPORT)]
    [RequireComponent(typeof(HeroInteractionDetector))]
    public class Teleport : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private HeroInteractionDetector _heroDetector;

        [SerializeField]
        private Transform _exit;

        private IHeroProvider _heroProvider;
        private HeroView _heroView;

        [Inject]
        public void Construct(IHeroProvider heroProvider, IExplicitInitializer initializer)
        {
            _heroProvider = heroProvider;
            initializer.Add(this);
            _heroDetector.OnHeroInteracted += TransitHero;
        }

        private void OnDestroy()
        {
            _heroDetector.OnHeroInteracted -= TransitHero;
        }

        public void Initialize()
        {
            _heroView = _heroProvider.HeroController?.View;
        }

        private void TransitHero()
        {
            _heroView.transform.position = _exit.position;
        }

        private void Reset()
        {
            _heroDetector = GetComponent<HeroInteractionDetector>();
        }
    }
}