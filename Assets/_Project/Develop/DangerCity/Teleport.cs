using DangerCity.Gameplay.Hero;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Teleport : MonoBehaviour
  {
    public GameObject Exit;
    private HeroModel _heroModel;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        _heroModel.CanTeleport.Value = true;
        _heroModel.TeleportPosition = Exit.transform.position;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        _heroModel.CanTeleport.Value = false;
    }
  }
}