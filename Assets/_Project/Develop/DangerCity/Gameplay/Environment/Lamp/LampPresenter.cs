using System;
using DangerCity.Infrastructure.LifeCycle;

namespace DangerCity.Gameplay.Environment.Lamp
{
    public class LampPresenter : ILampPresenter, IDisposable
    {
        private readonly GameModel _gameModel;
        private LampView _view;

        public LampPresenter(GameModel gameModel, IExplicitInitializer initializer)
        {
            _gameModel = gameModel;
            _gameModel.IsOpen.OnChanged += TurnOnLamp;
            initializer.Add(this);
        }

        public void Dispose()
        {
            _gameModel.IsOpen.OnChanged -= TurnOnLamp;
        }

        public void SetView(LampView view)
        {
            _view = view;
        }

        private void TurnOnLamp()
        {
            _view.SetOpenColor();
        }
    }
}