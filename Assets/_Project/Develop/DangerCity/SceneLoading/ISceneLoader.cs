namespace DangerCity.SceneLoading
{
    public interface ISceneLoader
    {
        SceneTuple CurrentScene { get; }
        void Load(SceneType id);
        void Load(int id);
    }
}