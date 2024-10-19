using DangerCity.SceneLoading;
using UnityEngine;
using Zenject;

namespace DangerCity.UI
{
    public class MainMenu : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void PlayBtn()
        {
            _sceneLoader.Load(SceneType.Level1);
        }

        public void ExitBtn()
        {
            Application.Quit();
        }
    }
}