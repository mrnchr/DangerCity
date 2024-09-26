using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace DangerCity.Boot.Installers
{
  [AddComponentMenu(ACC.Names.PROJECT_INSTALLER)]
  public class ProjectInstaller : MonoInstaller
  {
    [SerializeField]
    private ConfigProvider _configProvider;

    [SerializeField]
    private PlayerInput _input;

    [SerializeField]
    private EventSystem _eventSystem;
    
    public override void InstallBindings()
    {
      BindConfigProvider();
      BindInputData();
      BindPlayerInputActions();
      BindInputController();
    }

    private void BindConfigProvider()
    {
      Container
        .Bind<IConfigProvider>()
        .FromInstance(_configProvider)
        .AsSingle();
    }

    private void BindPlayerInputActions()
    {
      Container
        .BindInterfacesAndSelfTo<PlayerInputActions>()
        .AsSingle();
    }

    private void BindInputController()
    {
      Container
        .BindInterfacesTo<InputController>()
        .AsSingle()
        .WithArguments(_input);
    }

    private void BindInputData()
    {
      Container
        .Bind<InputData>()
        .AsSingle();
    }
  }
}