using System;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
  [AddComponentMenu(ACC.Names.HERO_INTERACTION_DETECTOR)]
  public class HeroInteractionDetector : MonoBehaviour, IInitializable
  {
    private IHeroProvider _heroProvider;
    private HeroView _heroView;
    private HeroModel _heroModel;

    public event Action OnHeroInteracted;

    [Inject]
    public void Construct(IHeroProvider heroProvider, IExplicitInitializer initializer)
    {
      _heroProvider = heroProvider;
      initializer.Add(this);
    }

    public void Initialize()
    {
      _heroView = _heroProvider.HeroController?.View;
      _heroModel = _heroProvider.HeroController?.Model;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (IsHeroCollision(collision))
      {
        _heroModel.OnInteracted += OnHeroInteracted;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (IsHeroCollision(collision))
      {
        _heroModel.OnInteracted -= OnHeroInteracted;
      }
    }

    private bool IsHeroCollision(Collider2D collision)
    {
      return _heroView && _heroView.Rigidbody == collision.attachedRigidbody;
    }
  }
}