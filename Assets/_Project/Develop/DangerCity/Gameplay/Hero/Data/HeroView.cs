using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.Hero.Data
{
    [AddComponentMenu(ACC.Names.HERO_VIEW)]
    public class HeroView : MonoBehaviour
    {
        public Transform StartPosition;
        public Animator Animator;
        public Rigidbody2D Rigidbody;
        public Transform GroundChecker;
        public HeroModel HeroModel;

        private void Reset()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }

        [Inject]
        public void Construct(IHeroController controller, HeroModel model)
        {
            controller.SetView(this);
            HeroModel = model;
        }
    }
}