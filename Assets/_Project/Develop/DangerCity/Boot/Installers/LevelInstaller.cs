using DangerCity.Gameplay;
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
    }

    private void BindGameModel()
    {
      Container
        .Bind<GameModel>()
        .AsSingle();
    }
  }
}