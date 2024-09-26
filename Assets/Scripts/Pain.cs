using UnityEngine;

public class Pain : MonoBehaviour
{
  private GameObject _player;
  private PlayerController _playerController;

  private void Awake()
  {
    _player = GameObject.FindGameObjectWithTag("Player");
    _playerController = _player.GetComponent<PlayerController>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
      _playerController.IsDie = true;
  }
}