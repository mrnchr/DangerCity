using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 movement;
    private bool Is_Right;
    public int coins;
    public Vector3 StartPosition;
    public Text Score;
    public float JumpForce;
    public bool isDie;
    private Rigidbody2D _rb;
    public float speedUpDown;
    public bool isLadder;
    public bool isGrounded;
    public bool isJump;
    public bool isWalk;
    public bool isTeleport;
    public Vector3 TeleportPosition;
    public bool isExit;
    private GameLogic EndLevel;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        isWalk = true;
        StartPosition = transform.position;
        Is_Right = true;
        coins = 0;
        Score.text = "Coins: " + coins.ToString();
        _rb = GetComponent<Rigidbody2D>();
        EndLevel = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin" && !isDie)
        {
            coins++;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Coins: " + coins.ToString();

        if (isDie)
        {
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<PlayerController>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Animator>().SetBool("IsJump", (isJump || isLadder));

        Joystick(joystick.Horizontal + Input.GetAxis("Horizontal"), joystick.Vertical + Input.GetAxis("Vertical"), Input.GetButton("Jump"), Input.GetKey(KeyCode.E));
    }

    private void Jump ()
    {
        _rb.gravityScale = 1;
        _rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        isJump = true;
    }

    public void Joystick(float horizontal = 0f, float vertical = 0f, bool jump = false, bool action = false)
    {
        if (jump && !isJump)
            Jump();
        if (isWalk)
            Walk(horizontal);
        if (isLadder)
            OnLadder(horizontal, vertical);

        if (action)
        {
            if (isTeleport)
            {
                transform.position = TeleportPosition;
            }

            if (isExit)
            {
                EndLevel.isWin = true;
            }
        }
    }

    /*void Walk ()
    {
        movement = new Vector2(Input.GetAxis("Horizontal")*speed, _rb.velocity.y);
        _rb.velocity = movement;

        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.GetComponent<Animator>().SetBool("IsRun", true);
            if (Is_Right)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
                Is_Right = false;
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("IsRun", true);
            if (!Is_Right)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
                Is_Right = true;
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("IsRun", false);
        }
    }*/

    void Walk(float direction = 0f)
    {
        movement = new Vector2(direction * speed, _rb.velocity.y);
        _rb.velocity = movement;

        if (direction < 0)
        {
            gameObject.GetComponent<Animator>().SetBool("IsRun", true);
            if (Is_Right)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
                Is_Right = false;
            }
        }
        else if (direction > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("IsRun", true);
            if (!Is_Right)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
                Is_Right = true;
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("IsRun", false);
        }
    }

    /*private void OnLadder()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speedUpDown, Input.GetAxis("Vertical") * speedUpDown, 0f);
        if (_rb.velocity.y < 0)
        {
            isJump = false;
            _rb.velocity = new Vector2(0f, 0f);
            _rb.gravityScale = 0;
        }
    }*/

    private void OnLadder(float horizontal = 0f, float vertical = 0f)
    {
        transform.position += new Vector3(horizontal * speedUpDown, vertical * speedUpDown, 0f);
        if (_rb.velocity.y < 0)
        {
            isJump = false;
            _rb.velocity = new Vector2(0f, 0f);
            _rb.gravityScale = 0;
        }
    }
}
