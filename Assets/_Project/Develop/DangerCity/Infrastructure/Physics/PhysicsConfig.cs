using UnityEngine;

namespace DangerCity.Infrastructure.Physics
{
    [CreateAssetMenu(fileName = CAC.Names.PHYSICS_FILE, menuName = CAC.Names.PHYSICS_MENU)]
    public class PhysicsConfig : ScriptableObject
    {
        public LayerMask GroundMask;
        public float AcceptableGroundDistance;
    }
}