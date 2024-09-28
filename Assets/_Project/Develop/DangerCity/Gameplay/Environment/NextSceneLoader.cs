using DangerCity.Gameplay.Hero;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Gameplay.Hero.Movement;
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

    [Inject]
    public void Construct(IHeroProvider heroProvider, GameModel gameModel)
    {
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
        int nextBuildIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextBuildIndex);
      }
    }

    private void Reset()
    {
      _heroDetector = GetComponent<HeroInteractionDetector>();
    }
  }
}