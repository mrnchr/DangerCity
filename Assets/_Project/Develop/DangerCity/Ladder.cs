using UnityEngine;

namespace DangerCity
{
  public class Ladder : MonoBehaviour
  {
    private PlayerController _controller;
    private Rigidbody2D _rb;
    private GameObject _player;

    private void Awake()
    {
      _player = GameObject.FindGameObjectWithTag("Player");
      _rb = _player.GetComponent<Rigidbody2D>();
      _controller = _player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        _rb.velocity = new Vector2(0f, 0f);
        _rb.gravityScale = 0;
        _player.layer = LayerMask.NameToLayer("OnLadder");

        _controller.IsJump = false;
        _controller.IsLadder = true;
        _controller.IsWalk = false;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        _player.layer = LayerMask.NameToLayer("Default");
        _rb.gravityScale = 1;
        _controller.IsLadder = false;
        _controller.IsWalk = true;
      }
    }
  }
}