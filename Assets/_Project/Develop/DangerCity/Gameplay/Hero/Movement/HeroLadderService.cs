using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Meta;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Movement
{
  public class HeroLadderService : IInitializable, IHeroLadderService
  {
    private readonly IHeroProvider _heroProvider;
    private readonly HeroModel _heroModel;
    private HeroView _heroView;

    public HeroLadderService(IHeroProvider heroProvider, HeroModel heroModel)
    {
      _heroProvider = heroProvider;
      _heroModel = heroModel;
    }
    
    public void Initialize()
    {
      _heroView = _heroProvider.HeroController?.View;
    }

    public void OnLadder()
    {
      if (!_heroView)
        return;
      
      _heroView.Rigidbody.velocity = new Vector2(0f, 0f);
      _heroView.Rigidbody.gravityScale = 0;
      _heroView.gameObject.layer = LayerMask.NameToLayer("OnLadder");

      _heroModel.IsJump.Value = false;
      _heroModel.IsLadder.Value = true;
      _heroModel.IsWalk.Value = false;
    }

    public void OnLeaveLadder()
    {
      if (!_heroView)
        return;
      
      _heroView.Rigidbody.gravityScale = 1;
      _heroView.gameObject.layer = LayerMask.NameToLayer("Default");
        
      _heroModel.IsLadder.Value = false;
      _heroModel.IsWalk.Value = true;
    }
  }
}