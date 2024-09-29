using DangerCity.Infrastructure;
using DangerCity.Infrastructure.LifeCycle;
using UnityEngine.SceneManagement;

namespace DangerCity.SceneLoading
{
  public class SceneLoader : ISceneLoader
  {
    private readonly SceneConfig _config;

    public SceneTuple CurrentScene { get; private set; } = new SceneTuple();

    public SceneLoader(IConfigProvider configProvider, ICoroutineRunner runner)
    {
      _config = configProvider.Get<SceneConfig>();
    }

    public void Load(SceneType id)
    {
      SceneTuple scene = _config.GetScene(id);
      CurrentScene = scene;
      SceneManager.LoadScene(scene.Name);
    }
    
    public void Load(int id)
    {
      SceneTuple scene = _config.GetScene(id);
      CurrentScene = scene;
      SceneManager.LoadScene(scene.Name);
    }
  }
}