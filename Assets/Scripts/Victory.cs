using UnityEngine;

public class Victory : MonoBehaviour
{
  private PlayerController _exit;

  private void Awake()
  {
    _exit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
      _exit.IsExit = true;
  }
}