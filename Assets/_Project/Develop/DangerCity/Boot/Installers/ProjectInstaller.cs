using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using DangerCity.Infrastructure.LifeCycle;
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
      BindExplicitInitializer();

      BindTimerFactory();
      BindTimerService();
    }

    private void BindTimerService()
    {
      Container
        .BindInterfacesTo<TimerService>()
        .AsSingle();
    }

    private void BindTimerFactory()
    {
      Container
        .Bind<ITimerFactory>()
        .To<TimerFactory>()
        .AsSingle();
    }

    private void BindExplicitInitializer()
    {
      Container
        .Bind<IExplicitInitializer>()
        .To<ExplicitInitializer>()
        .AsSingle()
        .CopyIntoAllSubContainers();
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
#if UNITY_STANDALONE
      Container
        .BindInterfacesTo<InputController>()
        .AsSingle()
        .WithArguments(_input);
#endif
    }

    private void BindInputData()
    {
      Container
        .Bind<InputData>()
        .AsSingle();
    }
  }
}