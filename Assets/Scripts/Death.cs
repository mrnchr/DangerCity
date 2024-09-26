using UnityEngine;

public class Death : StateMachineBehaviour
{
  private PlayerController _playerController;


  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (_playerController == null)
      _playerController = animator.GetComponent<PlayerController>();
    
    _playerController.enabled = true;
    animator.transform.position = _playerController.StartPosition;
    _playerController.IsDie = false;
  }
}