using System;
using DangerCity.Infrastructure.Input;
using DangerCity.Infrastructure.LifeCycle;
using DangerCity.SceneLoading;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class PlayMenu : MonoBehaviour, IInitializable, ITickable, IDisposable
  {
    public GameObject ControllerWindow;
    public GameObject MainMenu;
    private ISceneLoader _sceneLoader;
    private InputData _inputData;
    private IExplicitInitializer _initializer;

    [Inject]
    public void Construct(ISceneLoader sceneLoader, InputData inputData, IExplicitInitializer initializer)
    {
      _initializer = initializer;
      _inputData = inputData;
      _sceneLoader = sceneLoader;
      _initializer.Add(this);
    }

    public void Initialize()
    {
      MainMenu.SetActive(false);
    }

    public void Tick()
    {
      if (_inputData.Pause)
        ToggleMenu();
    }

    public void Dispose()
    {
      _initializer.Remove(this);
    }

    public void ToggleMenu()
    {
      ControllerWindow.SetActive(!ControllerWindow.activeSelf);
      MainMenu.SetActive(!MainMenu.activeSelf);
    }

    public void MainMenuBtn()
    {
      _sceneLoader.Load(SceneType.Menu);
    }
  }
}