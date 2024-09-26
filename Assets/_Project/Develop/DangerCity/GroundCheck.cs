using UnityEngine;

namespace DangerCity
{
  public class GroundCheck : MonoBehaviour
  {
    private PlayerController _playerController;
    private GameObject _player;

    private void Start()
    {
      _player = GameObject.FindGameObjectWithTag("Player");
      _playerController = _player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Ground"))
        _playerController.IsJump = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Ground"))
        _playerController.IsJump = true;
    }
  }
}