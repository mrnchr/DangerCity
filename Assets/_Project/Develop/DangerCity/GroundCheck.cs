using DangerCity.Gameplay.Hero;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Physics;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class GroundCheck : MonoBehaviour
  {
    private RaycastHit2D[] _hits;
    private ContactFilter2D _filter;
    private PhysicsConfig _physics;
    private HeroModel _heroModel;

    [Inject]
    public void Construct(IConfigProvider configProvider, HeroModel heroModel)
    {
      _heroModel = heroModel;
      _physics = configProvider.Get<PhysicsConfig>();
      
      _hits = new RaycastHit2D[5];
      _filter = new ContactFilter2D
      {
        useLayerMask = true,
        layerMask = _physics.GroundMask,
        useTriggers = false
      };
    }

    private void FixedUpdate()
    {
      _heroModel.IsJump = 0 >= Physics2D.CircleCast(transform.position, _physics.AcceptableGroundDistance,
        Vector2.zero, _filter, _hits);
    }
  }
}