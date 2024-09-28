using System;
using DangerCity.Gameplay;
using DangerCity.Gameplay.Hero.Movement;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  [RequireComponent(typeof(HeroDetector))]
  public class MainCoin : MonoBehaviour
  {
    [SerializeField]
    private HeroDetector _heroDetector;
    
    private GameModel _gameModel;

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

    private void OnDestroy()
    {
      _heroDetector.OnHeroDetected -= OpenExit;
    }

    private void Reset()
    {
      _heroDetector = GetComponent<HeroDetector>();
    }
  }
}