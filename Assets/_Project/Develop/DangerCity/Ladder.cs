using DangerCity.Gameplay.Hero;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Ladder : MonoBehaviour
  {
    private Rigidbody2D _rb;
    private GameObject _player;
    private HeroModel _heroModel;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
    }

    private void Awake()
    {
      _player = GameObject.FindGameObjectWithTag("Player");
      _rb = _player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        _rb.velocity = new Vector2(0f, 0f);
        _rb.gravityScale = 0;
        _player.layer = LayerMask.NameToLayer("OnLadder");

        _heroModel.IsJump.Value = false;
        _heroModel.IsLadder.Value = true;
        _heroModel.IsWalk.Value = false;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        _player.layer = LayerMask.NameToLayer("Default");
        _rb.gravityScale = 1;
        _heroModel.IsLadder.Value = false;
        _heroModel.IsWalk.Value = true;
      }
    }
  }
}