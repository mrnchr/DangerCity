namespace DangerCity.Infrastructure
{
  public interface ITimerFactory
  {
    Timer Create(float time, bool unscaled = false);
  }
}