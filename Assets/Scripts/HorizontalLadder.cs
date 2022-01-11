using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLadder : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerController _controller;

    private void Awake()
    {
        _rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundCheck")
        {
            _rb.velocity = new Vector2(0f, 0f);
            _rb.gravityScale = 0;

            _controller.isJump = false;
            _controller.isLadder = true;
            _controller.isWalk = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GroundCheck")
        {
            _rb.gravityScale = 1;
            _controller.isLadder = false;
            _controller.isWalk = true;
        }
    }
}
