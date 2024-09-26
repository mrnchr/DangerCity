using UnityEngine;
using UnityEngine.SceneManagement;

namespace DangerCity
{
  public class MainMenu : MonoBehaviour
  {
    public void PlayBtn()
    {
      SceneManager.LoadScene("Level 1");
    }

    public void ExitBtn()
    {
      Application.Quit();
    }
  }
}