using DangerCity.Infrastructure;

namespace DangerCity.Gameplay
{
    public class GameModel
    {
        public readonly CallbackValue<bool> IsOpen = new CallbackValue<bool>();
        public readonly CallbackValue<bool> IsWin = new CallbackValue<bool>();
    }
}