using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Color Green;
    private GameLogic Logic;

    private void Awake()
    {
        Logic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Logic.isOpen)
        {
            GetComponent<SpriteRenderer>().color = Green;
        }
    }
}
