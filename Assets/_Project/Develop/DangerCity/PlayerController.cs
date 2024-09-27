using DangerCity.Gameplay;
using DangerCity.Gameplay.Hero;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class PlayerController : MonoBehaviour
  {
    public Vector3 StartPosition;
    public Joystick joystick;
    public HeroModel HeroModel;

    [SerializeField]
    private Animator _animator;
    
    private Rigidbody2D _rb;
    private GameModel _gameModel;
    private InputData _inputData;
    private HeroInventory _inventory;
    private HeroConfig _config;

    [Inject]
    public void Construct(GameModel gameModel,
      InputData inputData,
      HeroInventory inventory,
      HeroModel heroModel,
      IConfigProvider configProvider,
      IHeroAnimator heroAnimator)
    {
      HeroModel = heroModel;
      _inventory = inventory;
      _inputData = inputData;
      _gameModel = gameModel;
      _config = configProvider.Get<HeroConfig>();
      _rb = GetComponent<Rigidbody2D>();
      
      heroAnimator.SetAnimator(_animator);
    }

    private void Start()
    {
      HeroModel.IsWalk.Value = true;
      StartPosition = transform.position;
    }

    private void Update()
    {
      Joystick(joystick.Horizontal + _inputData.Movement.x, joystick.Vertical + _inputData.Movement.y,
        _inputData.Jump, _inputData.Interact);

      if (HeroModel.IsDie)
      {
        enabled = false;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Coin") && !HeroModel.IsDie)
      {
        _inventory.Coins.Value++;
        Destroy(collision.gameObject);
      }
    }

    private void Jump()
    {
      _rb.gravityScale = 1;
      _rb.velocity = new Vector2(_rb.velocity.x, 0);
      _rb.AddForce(Vector2.up * _config.JumpForce, ForceMode2D.Impulse);
      HeroModel.IsJump.Value = true;
    }

    public void Joystick(float horizontal = 0f, float vertical = 0f, bool jump = false, bool action = false)
    {
      if (jump && (!HeroModel.IsJump || HeroModel.IsLadder))
        Jump();
      if (HeroModel.IsWalk)
        Walk(horizontal);
      if (HeroModel.IsLadder)
        OnLadder(horizontal, vertical);

      if (action)
      {
        if (HeroModel.CanTeleport)
          transform.position = HeroModel.TeleportPosition;

        if (HeroModel.IsExit)
          _gameModel.IsWin.Value = true;
      }
    }

    private void Walk(float direction = 0f)
    {
      _rb.velocity = new Vector2(direction * _config.Speed, _rb.velocity.y);
      HeroModel.IsMove.Value = direction != 0;

      if (direction != 0)
      {
        HeroModel.BodyDirection.Value = Mathf.Sign(direction);
        transform.eulerAngles = new Vector3(0, direction > 0 ? 0 : 180, 0);
      }
    }

    private void OnLadder(float horizontal = 0f, float vertical = 0f)
    {
      if (_rb.gravityScale != 0)
      {
        HeroModel.IsJump.Value = false;
        _rb.gravityScale = 0;
      }

      Vector2 direction = new Vector2(horizontal, vertical).normalized;
      _rb.velocity = direction * _config.SpeedOnLadder;
    }

    private void Reset()
    {
      _animator = GetComponent<Animator>();
    }
  }
}