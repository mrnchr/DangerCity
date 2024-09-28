using DangerCity.Gameplay.Hero.Data;
using DangerCity.Gameplay.Hero.Movement;
using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Environment
{
  [AddComponentMenu(ACC.Names.DEATH_ACTIVATOR)]
  [RequireComponent(typeof(HeroDetector))]
  public class DeathActivator : MonoBehaviour
  {
    [SerializeField]
    private HeroDetector _heroDetector;
    
    private HeroModel _heroModel;

    [Inject]
    public void Construct(HeroModel heroModel)
    {
      _heroModel = heroModel;
      _heroDetector.OnHeroDetected += DieHero;
    }

    private void DieHero()
    {
      _heroModel.IsDie.Value = true;
    }

    private void Reset()
    {
      _heroDetector = GetComponent<HeroDetector>();
    }
  }
}