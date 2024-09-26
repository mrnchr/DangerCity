using System;
using DangerCity.Gameplay;
using DangerCity.Infrastructure.Input;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DangerCity
{
  public class PlayerController : MonoBehaviour
  {
    private static readonly int _die = Animator.StringToHash("Die");
    private static readonly int _isJump = Animator.StringToHash("IsJump");
    private static readonly int _isRun = Animator.StringToHash("IsRun");
    
    public float Speed = 1f;
    public int Coins;
    public Vector3 StartPosition;
    public Text Score;
    public float JumpForce;
    public bool IsDie;
    public float SpeedUpDown;
    public bool IsLadder;
    public bool IsJump;
    public bool IsWalk;
    public bool IsTeleport;
    public Vector3 TeleportPosition;
    public bool IsExit;
    public Joystick joystick;

    private Rigidbody2D _rb;
    private Animator _animator;
    private GameModel _gameModel;
    private InputData _inputData;

    [Inject]
    public void Construct(GameModel gameModel, InputData inputData)
    {
      _inputData = inputData;
      _gameModel = gameModel;
      
      _animator = GetComponent<Animator>();
      _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
      IsWalk = true;
      StartPosition = transform.position;
      Coins = 0;
      Score.text = "Coins: " + Coins;
    }

    private void Update()
    {
      _animator.SetBool(_isJump, IsJump || IsLadder);
      
      Joystick(joystick.Horizontal + _inputData.Movement.x, joystick.Vertical + _inputData.Movement.y,
        _inputData.Jump, _inputData.Interact);
      
      Score.text = "Coins: " + Coins;

      if (IsDie)
      {
        _animator.SetTrigger(_die);
        enabled = false;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Coin") && !IsDie)
      {
        Coins++;
        Destroy(collision.gameObject);
      }
    }

    private void Jump()
    {
      _rb.gravityScale = 1;
      _rb.velocity = new Vector2(_rb.velocity.x, 0);
      _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
      IsJump = true;
    }

    public void Joystick(float horizontal = 0f, float vertical = 0f, bool jump = false, bool action = false)
    {
      if (jump && !IsJump)
        Jump();
      if (IsWalk)
        Walk(horizontal);
      if (IsLadder)
        OnLadder(horizontal, vertical);

      if (action)
      {
        if (IsTeleport)
          transform.position = TeleportPosition;

        if (IsExit)
          _gameModel.IsWin.Value = true;
      }
    }

    private void Walk(float direction = 0f)
    {
      _rb.velocity = new Vector2(direction * Speed, _rb.velocity.y);

      _animator.SetBool(_isRun, direction != 0);
      if (direction != 0)
        transform.eulerAngles = new Vector3(0, direction > 0 ? 0 : 180, 0);
    }

    private void OnLadder(float horizontal = 0f, float vertical = 0f)
    {
      if (_rb.gravityScale != 0)
      {
        IsJump = false;
        _rb.gravityScale = 0;
      }
    
      _rb.velocity = new Vector3(horizontal * SpeedUpDown, vertical * SpeedUpDown, 0f);
    }
  }
}