using System;
using DangerCity.Gameplay.Hero;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Gameplay.Hero.Movement;
using DangerCity.SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DangerCity.Gameplay.Environment
{
  [AddComponentMenu(ACC.Names.NEXT_SCENE_LOADER)]
  [RequireComponent(typeof(HeroInteractionDetector))]
  public class NextSceneLoader : MonoBehaviour
  {
    [SerializeField]
    private HeroInteractionDetector _heroDetector;

    private GameModel _gameModel;
    private ISceneLoader _sceneLoader;

    [Inject]
    public void Construct(IHeroProvider heroProvider, GameModel gameModel, ISceneLoader sceneLoader)
    {
      _sceneLoader = sceneLoader;
      _gameModel = gameModel;
      _heroDetector.OnHeroInteracted += MoveToNextLevel;
    }

    private void OnDestroy()
    {
      _heroDetector.OnHeroInteracted -= MoveToNextLevel;
    }

    private void MoveToNextLevel()
    {
      if (_gameModel.IsOpen)
      {
        _gameModel.IsWin.Value = true;
        int nextScene = ((int)_sceneLoader.CurrentScene.Id + 1) % typeof(SceneType).GetEnumValues().Length;
        _sceneLoader.Load(nextScene);
      }
    }

    private void Reset()
    {
      _heroDetector = GetComponent<HeroInteractionDetector>();
    }
  }
}