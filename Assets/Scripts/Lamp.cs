using UnityEngine;

public class Lamp : MonoBehaviour
{
  public Color Green;
  private GameLogic _logic;
  private SpriteRenderer _spriteRenderer;

  private void Awake()
  {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
  }

  // Update is called once per frame
  private void Update()
  {
    if (_logic.IsOpen)
      _spriteRenderer.color = Green;
  }
}