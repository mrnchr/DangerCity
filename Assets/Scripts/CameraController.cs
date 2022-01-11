using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private GameObject _player;
    private float BottomY, LeftX, RightX, TopY;// ћаксимальные значени€, которые может принимать камера
    private Vector3 Coordinate;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        transform.position += _player.transform.position;

        BottomY = -2.5f;
        TopY = 2.5f;
        LeftX = -4.49f;
        RightX = 4.49f;
    }

    // Update is called once per frame
    void Update()
    {
        Coordinate = _player.transform.position;
        Coordinate.z = transform.position.z;
        // ¬ычисл€ем координаты камеры, если она вышла за пределы сцены
        Coordinate.x = Coordinate.x < LeftX ? LeftX : Coordinate.x;
        Coordinate.x = Coordinate.x > RightX ? RightX : Coordinate.x;
        Coordinate.y = Coordinate.y < BottomY ? BottomY : Coordinate.y;
        Coordinate.y = Coordinate.y > TopY ? TopY : Coordinate.y;
        transform.position = Coordinate;
    }
}
