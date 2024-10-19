using System;
using System.Collections.Generic;
using UnityEngine;

namespace DangerCity.SceneLoading
{
    [CreateAssetMenu(menuName = CAC.Names.SCENE_CONFIG_MENU, fileName = CAC.Names.SCENE_CONFIG_FILE)]
    public class SceneConfig : ScriptableObject
    {
        [SerializeField]
        private List<SceneTuple> _scenes;

        public SceneTuple GetScene(SceneType id)
        {
            return _scenes.Find(x => x.Id == id);
        }

        public SceneTuple GetScene(int id)
        {
            return _scenes.Find(x => (int)x.Id == id);
        }

        public SceneTuple GetScene(string sceneName)
        {
            return _scenes.Find(x => x.Name == sceneName);
        }
    }

    [Serializable]
    public class SceneTuple
    {
        public SceneType Id;
        public string Name;
    }
}