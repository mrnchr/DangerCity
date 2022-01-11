using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCoin : MonoBehaviour
{
    private GameLogic CatchCoin;

    private void Awake()
    {
        CatchCoin = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CatchCoin.isOpen = true;
        }
    }
}
