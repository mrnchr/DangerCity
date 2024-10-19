using UnityEngine;
using Zenject;

namespace DangerCity.Gameplay.FlexibleCamera
{
    [AddComponentMenu(ACC.Names.CAMERA_VIEW)]
    public class CameraView : MonoBehaviour
    {
        public float Bottom;
        public float Top;
        public float Left;
        public float Right;

        [Inject]
        public void Construct(ICameraController controller)
        {
            controller.SetView(this);
        }
    }
}