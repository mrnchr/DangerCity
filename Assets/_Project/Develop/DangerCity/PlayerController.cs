using DangerCity.Gameplay;
using DangerCity.Gameplay.Hero;
using DangerCity.Infrastructure;
using DangerCity.Infrastructure.Input;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DangerCity
{
  public class PlayerController : MonoBehaviour
  {
    public Vector3 StartPosition;
    public Joystick joystick;
    public HeroModel HeroModel;

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
      IConfigProvider configProvider)
    {
      HeroModel = heroModel;
      _inventory = inventory;
      _inputData = inputData;
      _gameModel = gameModel;
      _config = configProvider.Get<HeroConfig>();
      _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
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
    
    public void Joystick(float horizontal = 0f, float vertical = 0f, bool jump = false, bool action = false)
    {
      if (HeroModel.IsLadder)
        OnLadder(horizontal, vertical);

      if (action)
      {
        if (HeroModel.CanTeleport)
          transform.position = HeroModel.TeleportPosition;

        if (HeroModel.IsExit)
        {
          _gameModel.IsWin.Value = true;
          int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
          if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextBuildIndex);
        }
      }
    }

    private void OnLadder(float horizontal = 0f, float vertical = 0f)
    {
      if (_rb.velocity.y < 0)
      {
        HeroModel.IsJump.Value = false;
        _rb.gravityScale = 0;
      }

      Vector2 direction = new Vector2(horizontal, vertical).normalized;
      _rb.velocity = direction * _config.SpeedOnLadder;
    }
  }
}