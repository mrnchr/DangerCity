using DangerCity.Gameplay.Hero;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Victory : MonoBehaviour
  {
    private HeroModel _heroModel;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        _heroModel.IsExit.Value = true;
    }
  }
}