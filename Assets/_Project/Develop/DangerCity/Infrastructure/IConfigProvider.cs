using System.Collections.Generic;
using UnityEngine;

namespace DangerCity.Infrastructure
{
  public interface IConfigProvider
  {
    TConfig Get<TConfig>() where TConfig : ScriptableObject;
    List<ScriptableObject> Configs { get; }
  }
}