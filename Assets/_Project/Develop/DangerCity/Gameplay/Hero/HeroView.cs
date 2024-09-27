using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero
{
  [AddComponentMenu(ACC.Names.HERO_VIEW)]
  public class HeroView : MonoBehaviour
  {
    public Vector3 StartPosition;
    public Joystick joystick;
    public HeroModel HeroModel;

    [SerializeField]
    private Animator _animator;
    
    [SerializeField]
    private Rigidbody2D _rb;
    
    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody => _rb;
    
    [Inject]
    public void Construct(IHeroController controller, HeroModel model)
    {
      controller.SetView(this);
      HeroModel = model;
    }
    
    private void Reset()
    {
      _rb = GetComponent<Rigidbody2D>();
      _animator = GetComponent<Animator>();
    }
  }
}