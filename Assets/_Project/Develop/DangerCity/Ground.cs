using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Ground : MonoBehaviour, IInitializable, IFixedTickable
  {
    [SerializeField]
    private Collider2D _groundCollider;

    private IExplicitInitializer _initializer;
    private IHeroProvider _heroProvider;
    private Transform _groundChecker;

    [Inject]
    public void Construct(IExplicitInitializer initializer, IHeroProvider heroProvider)
    {
      _initializer = initializer;
      _heroProvider = heroProvider;
      _initializer.Add(this);
    }

    public void Initialize()
    {
      _groundChecker = _heroProvider.HeroController?.View.GroundChecker;
    }

    public void FixedTick()
    {
      _groundCollider.isTrigger = transform.position.y + _groundCollider.offset.y > _groundChecker.transform.position.y;
    }

    private void OnDestroy()
    {
     _initializer.Remove(this);
    }

    private void Reset()
    {
      _groundCollider = GetComponent<Collider2D>();
    }
  }
}