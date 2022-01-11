using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public GameObject Score;
    public GameObject MainMenu;

    private void Awake()
    {
        Score.SetActive(true);
        MainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        Score.SetActive(!Score.activeSelf);
        MainMenu.SetActive(!MainMenu.activeSelf);
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }
}
