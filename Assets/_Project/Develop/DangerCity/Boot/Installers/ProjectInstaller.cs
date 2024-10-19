using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using DangerCity.Infrastructure.LifeCycle;
using DangerCity.SceneLoading;
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
            BindCoroutineRunner();
            BindConfigProvider();
            BindInputData();
            BindPlayerInputActions();
            BindInputController();
            BindExplicitInitializer();

            BindSceneLoader();

            BindTimerFactory();
            BindTimerService();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("CoroutineRunner")
                .UnderTransform(x => x.Container.Resolve<Context>().transform)
                .AsSingle()
                .CopyIntoDirectSubContainers();
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