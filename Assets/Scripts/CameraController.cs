using UnityEngine;

public class CameraController : MonoBehaviour
{
  private GameObject _player;
  private float _bottom, _left, _right, _top;

  private Vector3 _coordinate;

  private void Awake()
  {
    _player = GameObject.FindGameObjectWithTag("Player");

    _bottom = -2.5f;
    _top = 2.5f;
    _left = -4.49f;
    _right = 4.49f;
  }

  private void LateUpdate()
  {
    _coordinate = _player.transform.position;
    _coordinate.z = transform.position.z;
    _coordinate.x = Mathf.Clamp(_coordinate.x, _left, _right);
    _coordinate.y = Mathf.Clamp(_coordinate.y, _bottom, _top);
    transform.position = _coordinate;
  }
}