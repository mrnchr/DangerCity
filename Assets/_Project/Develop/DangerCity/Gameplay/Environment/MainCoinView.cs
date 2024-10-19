using DangerCity.Gameplay.Hero.Movement;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Environment
{
    [AddComponentMenu(ACC.Names.MAIN_COIN_VIEW)]
    [RequireComponent(typeof(HeroDetector))]
    public class MainCoinView : MonoBehaviour
    {
        [SerializeField]
        private HeroDetector _heroDetector;

        private GameModel _gameModel;

        private void Reset()
        {
            _heroDetector = GetComponent<HeroDetector>();
        }

        private void OnDestroy()
        {
            _heroDetector.OnHeroDetected -= OpenExit;
        }

        [Inject]
        public void Construct(GameModel gameModel)
        {
            _heroDetector = GetComponent<HeroDetector>();
            _gameModel = gameModel;

            _heroDetector.OnHeroDetected += OpenExit;
        }

        private void OpenExit()
        {
            _gameModel.IsOpen.Value = true;
        }
    }
}