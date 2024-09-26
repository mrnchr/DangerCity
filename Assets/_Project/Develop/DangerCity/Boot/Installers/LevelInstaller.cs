using DangerCity.Gameplay;
using DangerCity.Gameplay.Lamp;
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

      BindLampPresenter();
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