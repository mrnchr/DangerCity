using DangerCity.Infrastructure;
using UnityEngine.SceneManagement;

namespace DangerCity.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly SceneConfig _config;

        public SceneLoader(IConfigProvider configProvider)
        {
            _config = configProvider.Get<SceneConfig>();
            CurrentScene = _config.GetScene(SceneManager.GetActiveScene().name);
        }

        public SceneTuple CurrentScene { get; private set; }

        public void Load(SceneType id)
        {
            LoadScene(_config.GetScene(id));
        }

        public void Load(int id)
        {
            LoadScene(_config.GetScene(id));
        }

        private void LoadScene(SceneTuple scene)
        {
            CurrentScene = scene;
            SceneManager.LoadScene(scene.Name);
        }
    }
}