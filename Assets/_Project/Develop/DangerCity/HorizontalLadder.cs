using DangerCity.Gameplay.Hero;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class HorizontalLadder : MonoBehaviour
  {
    private HeroModel _heroModel;
    private Rigidbody2D _rb;
    private GameObject _player;
    private Collider2D _collGround;
    private GameObject _groundCheck;
    
    private bool _active;
    private bool _hasHero;
    private bool _onLadder;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
      _player = GameObject.FindGameObjectWithTag("Player");
      _groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
      _rb = _player.GetComponent<Rigidbody2D>();
      _collGround = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
      _active = transform.position.y + _collGround.offset.y > _groundCheck.transform.position.y;

      SetOnLadder(_active && _hasHero);
    }

    private void SetOnLadder(bool value)
    {
      switch (_onLadder, value)
      {
        case (false, true):
          OnLadder();
          break;
        case (true, false):
          NotOnLadder();
          break;
      }
    }

    private void OnLadder()
    {
      _onLadder = true;
      
      _rb.velocity = new Vector2(0f, 0f);
      _rb.gravityScale = 0;

      _heroModel.IsJump.Value = false;
      _heroModel.IsLadder.Value = true;
      _heroModel.IsWalk.Value = false;
    }

    private void NotOnLadder()
    {
      _onLadder = false;
      
      _rb.gravityScale = 1;
      _heroModel.IsLadder.Value = false;
      _heroModel.IsWalk.Value = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        _hasHero = true;
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        _hasHero = false;
      }
    }
  }
}