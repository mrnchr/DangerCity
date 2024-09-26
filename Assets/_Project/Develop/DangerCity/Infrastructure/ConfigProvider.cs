using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DangerCity.Infrastructure
{
  [CreateAssetMenu(fileName = CAC.Names.CONFIG_PROVIDER_FILE, menuName = CAC.Names.CONFIG_PROVIDER_MENU, order = 0)]
  public class ConfigProvider : ScriptableObject, IConfigProvider
  {
    [SerializeField]
    private List<ScriptableObject> _configs;

    public List<ScriptableObject> Configs => _configs;

    public TConfig Get<TConfig>() where TConfig : ScriptableObject
    {
      return Configs.OfType<TConfig>().First();
    }
  }
}