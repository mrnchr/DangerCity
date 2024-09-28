using DangerCity.Gameplay.Hero.Meta;
using DangerCity.Gameplay.Hero.Movement;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  [AddComponentMenu(ACC.Names.HORIZONTAL_LADDER)]
  [RequireComponent(typeof(HeroDetector))]
  public class HorizontalLadder : MonoBehaviour, IInitializable, IFixedTickable
  {
    [SerializeField]
    private Collider2D _collider;

    private Transform _groundChecker;

    private bool _active;
    private bool _hasHero;
    private bool _onLadder;
    private IExplicitInitializer _initializer;
    private IHeroProvider _heroProvider;

    [Inject]
    public void Construct(IHeroProvider heroProvider, IExplicitInitializer initializer)
    {
      _heroProvider = heroProvider;
      _initializer = initializer;
      _collider = GetComponent<Collider2D>();

      _initializer.Add(this);
    }

    public void Initialize()
    {
      _groundChecker = _heroProvider.HeroController?.View.GroundChecker;
    }

    public void FixedTick()
    {
      if (_groundChecker)
        _collider.enabled = transform.position.y + _collider.offset.y <= _groundChecker.position.y;
    }

    private void OnDestroy()
    {
      _initializer.Remove(this);
    }

    private void Reset()
    {
      _collider = GetComponent<Collider2D>();
    }
  }
}