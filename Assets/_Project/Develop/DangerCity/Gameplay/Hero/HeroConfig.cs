using UnityEngine;

namespace DangerCity.Gameplay.Hero
{
  [CreateAssetMenu(menuName = CAC.Names.HERO_CONFIG_MENU, fileName = CAC.Names.HERO_CONFIG_FILE)]
  public class HeroConfig : ScriptableObject
  {
    public float Speed;
    public float JumpForce;
    public float SpeedOnLadder;
    public float DeathDuration;

  }
}