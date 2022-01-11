using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameObject _groundCheck;
    private Collider2D _collGround;

    private void Awake()
    {
        _groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        _collGround = GetComponent<Collider2D>();
    }

    private void Update()
    {
        _collGround.isTrigger = transform.position.y + _collGround.offset.y > _groundCheck.transform.position.y;
    }
}
