namespace DangerCity.Infrastructure.LifeCycle
{
  public interface IExplicitInitializer
  {
    void Add(object obj);
    void Remove(object obj);
  }
}