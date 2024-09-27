using DangerCity.Gameplay.Hero;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Death : StateMachineBehaviour
  {
    private PlayerController _playerController;
    private HeroModel _heroModel;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if (_playerController == null)
        _playerController = animator.GetComponent<PlayerController>();
    
      _playerController.enabled = true;
      animator.transform.position = _playerController.StartPosition;
      _heroModel.IsDie.Value = false;
    }
  }
}