using UnityEngine;
using UnityEngine.SceneManagement;

namespace DangerCity
{
  public class LevelMenu : MonoBehaviour
  {
    public GameObject LevelSelection;
    public GameObject MainMenu;

    private void Awake()
    {
      MainMenu.SetActive(true);
      LevelSelection.SetActive(false);
    }

    public void ToggleMenu()
    {
      LevelSelection.SetActive(!LevelSelection.activeSelf);
      MainMenu.SetActive(!MainMenu.activeSelf);
    }

    public void SelectLevel(string nameScene)
    {
      if (SceneManager.GetActiveScene().name != nameScene)
        SceneManager.LoadScene(nameScene);
    }
  }
}