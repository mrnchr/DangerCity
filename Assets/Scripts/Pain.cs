using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pain : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Player.GetComponent<PlayerController>().isDie = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
