using DangerCity.Gameplay;
using DangerCity.Gameplay.Environment.Lamp;
using DangerCity.Gameplay.FlexibleCamera;
using DangerCity.Gameplay.Hero;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Gameplay.Hero.Movement;
using DangerCity.Infrastructure.Input;
using DangerCity.UI;
using DangerCity.UI.Buttons;
using DangerCity.UI.Coins;
using UnityEngine;
using Zenject;

namespace DangerCity.Boot.Installers
{
    [AddComponentMenu(ACC.Names.LEVEL_INSTALLER)]
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInteractionButtonModel();
            BindJumpButtonModel();
            BindMenuButtonModel();
            BindJoystickModel();
            BindMobileInputController();

            BindGameModel();
            BindHeroInventory();
            BindHeroModel();
            BindHeroProcessorFactory();
            BindHeroController();
            BindHeroProvider();
            BindHeroInitializer();

            BindHeroLadderService();

            BindLampPresenter();
            BindCoinsPresenter();

            BindCameraController();
        }

        private void BindMobileInputController()
        {
#if UNITY_ANDROID
            Container
                .BindInterfacesTo<MobileInputController>()
                .AsSingle();
#endif
        }

        private void BindJoystickModel()
        {
            Container
                .Bind<JoystickModel>()
                .AsSingle();
        }

        private void BindMenuButtonModel()
        {
            Container
                .Bind<MenuButtonModel>()
                .AsSingle();
        }

        private void BindJumpButtonModel()
        {
            Container
                .Bind<JumpButtonModel>()
                .AsSingle();
        }

        private void BindInteractionButtonModel()
        {
            Container
                .Bind<InteractionButtonModel>()
                .AsSingle();
        }

        private void BindHeroLadderService()
        {
            Container
                .BindInterfacesTo<HeroLadderService>()
                .AsSingle();
        }

        private void BindCameraController()
        {
            Container
                .Bind<ICameraController>()
                .To<CameraController>()
                .AsSingle();
        }

        private void BindHeroInitializer()
        {
            Container
                .BindInterfacesTo<HeroInitializer>()
                .AsSingle();
        }

        private void BindHeroProvider()
        {
            Container
                .Bind<IHeroProvider>()
                .To<HeroProvider>()
                .AsSingle();
        }

        private void BindHeroController()
        {
            Container
                .Bind<IHeroController>()
                .To<HeroController>()
                .AsSingle();
        }

        private void BindHeroProcessorFactory()
        {
            Container
                .Bind<IHeroProcessorFactory>()
                .To<HeroProcessorFactory>()
                .AsSingle();
        }

        private void BindHeroModel()
        {
            Container
                .Bind<HeroModel>()
                .AsSingle();
        }

        private void BindHeroInventory()
        {
            Container
                .Bind<HeroInventory>()
                .AsSingle();
        }

        private void BindCoinsPresenter()
        {
            Container
                .Bind<ICoinsPresenter>()
                .To<CoinsPresenter>()
                .AsSingle();
        }

        private void BindLampPresenter()
        {
            Container
                .Bind<ILampPresenter>()
                .To<LampPresenter>()
                .AsTransient();
        }

        private void BindGameModel()
        {
            Container
                .Bind<GameModel>()
                .AsSingle();
        }
    }
}