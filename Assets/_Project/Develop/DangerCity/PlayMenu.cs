using UnityEngine;
using UnityEngine.SceneManagement;

namespace DangerCity
{
  public class PlayMenu : MonoBehaviour
  {
    public GameObject Score;
    public GameObject MainMenu;

    private void Awake()
    {
      Score.SetActive(true);
      MainMenu.SetActive(false);
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        ToggleMenu();
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
}