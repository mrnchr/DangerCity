namespace DangerCity.Gameplay.Hero.Movement
{
  public class HeroStartProcessor : IHeroProcessor, IInitializableProcessor
  {
    private readonly IHeroController _controller;

    public HeroStartProcessor(IHeroController controller)
    {
      _controller = controller;
    }

    public void Initialize()
    {
      RestartHero();
    }

    public void RestartHero()
    {
      _controller.View.transform.position = _controller.View.StartPosition.position;
      _controller.Model.CanMove.Value = true;
    }
  }
}