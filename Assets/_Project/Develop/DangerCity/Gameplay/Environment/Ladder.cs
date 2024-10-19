using DangerCity.Gameplay.Hero.Movement;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Environment
{
    [AddComponentMenu(ACC.Names.LADDER)]
    [RequireComponent(typeof(HeroDetector))]
    public class Ladder : MonoBehaviour
    {
        [SerializeField]
        private HeroDetector _heroDetector;

        private IHeroLadderService _heroLadderSvc;

        private void Reset()
        {
            _heroDetector = GetComponent<HeroDetector>();
        }

        private void OnDestroy()
        {
            _heroDetector.OnHeroDetected -= OnHeroLadder;
            _heroDetector.OnHeroLost -= OnHeroLeaveLadder;
        }

        [Inject]
        public void Construct(IHeroLadderService heroLadderSvc)
        {
            _heroLadderSvc = heroLadderSvc;
            _heroDetector = GetComponent<HeroDetector>();

            _heroDetector.OnHeroDetected += OnHeroLadder;
            _heroDetector.OnHeroLost += OnHeroLeaveLadder;
        }

        private void OnHeroLadder()
        {
            _heroLadderSvc.OnLadder();
        }

        private void OnHeroLeaveLadder()
        {
            _heroLadderSvc.OnLeaveLadder();
        }
    }
}