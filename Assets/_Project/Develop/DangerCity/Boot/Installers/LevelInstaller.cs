using DangerCity.Gameplay;
using DangerCity.Gameplay.Hero;
using DangerCity.Gameplay.Lamp;
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
      BindGameModel();
      BindHeroInventory();
      BindHeroModel();
      BindHeroAnimator();

      BindLampPresenter();
      BindCoinsPresenter();
    }

    private void BindHeroAnimator()
    {
      Container
        .Bind<IHeroAnimator>()
        .To<HeroAnimator>()
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