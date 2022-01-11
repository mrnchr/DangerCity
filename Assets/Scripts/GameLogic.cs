using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public bool isOpen;
    public bool isWin;

    private void Awake()
    {
        isOpen = false;
        isWin = false;
    }
}
