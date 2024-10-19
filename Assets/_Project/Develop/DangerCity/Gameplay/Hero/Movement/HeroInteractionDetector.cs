using System;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
    [AddComponentMenu(ACC.Names.HERO_INTERACTION_DETECTOR)]
    [RequireComponent(typeof(HeroDetector))]
    public class HeroInteractionDetector : MonoBehaviour
    {
        [SerializeField]
        private HeroDetector _heroDetector;

        private HeroModel _heroModel;

        private IHeroProvider _heroProvider;

        private void Reset()
        {
            _heroDetector = GetComponent<HeroDetector>();
        }

        private void OnDestroy()
        {
            _heroDetector.OnHeroDetected -= SubscribeToHeroInteraction;
            _heroDetector.OnHeroLost -= UnsubscribeFromHeroInteraction;
            _heroModel.OnInteracted -= OnHeroInteracted;
        }

        public event Action OnHeroInteracted;

        [Inject]
        public void Construct(HeroModel heroModel)
        {
            _heroModel = heroModel;
            _heroDetector.OnHeroDetected += SubscribeToHeroInteraction;
            _heroDetector.OnHeroLost += UnsubscribeFromHeroInteraction;
        }

        private void SubscribeToHeroInteraction()
        {
            _heroModel.OnInteracted += OnHeroInteracted;
        }

        private void UnsubscribeFromHeroInteraction()
        {
            _heroModel.OnInteracted -= OnHeroInteracted;
        }
    }
}