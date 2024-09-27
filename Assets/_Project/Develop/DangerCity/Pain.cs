using DangerCity.Gameplay.Hero;
using UnityEngine;
using Zenject;

namespace DangerCity
{
  public class Pain : MonoBehaviour
  {
    private HeroModel _heroModel;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
        _heroModel.IsDie.Value = true;
    }
  }
}