using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero
{
  [AddComponentMenu(ACC.Names.HERO_VIEW)]
  public class HeroView : MonoBehaviour
  {
    public Vector3 StartPosition;
    public Joystick Joystick;
    public HeroModel HeroModel;

    public Animator Animator;
    public Rigidbody2D Rigidbody;
    public Transform GroundChecker;
    
    [Inject]
    public void Construct(IHeroController controller, HeroModel model)
    {
      controller.SetView(this);
      HeroModel = model;
    }
    
    private void Reset()
    {
      Rigidbody = GetComponent<Rigidbody2D>();
      Animator = GetComponent<Animator>();
    }
  }
}