using UnityEngine;

namespace DangerCity
{
  public class Teleport : MonoBehaviour
  {
    public GameObject Exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        collision.GetComponent<PlayerController>().IsTeleport = true;
        collision.GetComponent<PlayerController>().TeleportPosition = Exit.transform.position;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        collision.GetComponent<PlayerController>().IsTeleport = false;
    }
  }
}