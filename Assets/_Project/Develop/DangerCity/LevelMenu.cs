using DangerCity.Infrastructure.LifeCycle;
using DangerCity.SceneLoading;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class LevelMenu : MonoBehaviour, IInitializable
  {
    public GameObject LevelSelection;
    public GameObject MainMenu;
    
    private ISceneLoader _sceneLoader;

    [Inject]
    public void Construct(ISceneLoader sceneLoader, IExplicitInitializer initializer)
    {
      _sceneLoader = sceneLoader;
      initializer.Add(this);
    }

    public void Initialize()
    {
      MainMenu.SetActive(true);
      LevelSelection.SetActive(false);
    }

    public void ToggleMenu()
    {
      LevelSelection.SetActive(!LevelSelection.activeSelf);
      MainMenu.SetActive(!MainMenu.activeSelf);
    }

    public void SelectLevel(int index)
    {
      SceneType sceneType = SceneType.Level1 + index;
      if (_sceneLoader.CurrentScene.Id != sceneType)
        _sceneLoader.Load(sceneType);
    }
  }
}