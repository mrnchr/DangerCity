using System.Collections.Generic;
using UnityEngine;

namespace DangerCity.Infrastructure
{
    public interface IConfigProvider
    {
        List<ScriptableObject> Configs { get; }
        TConfig Get<TConfig>() where TConfig : ScriptableObject;
    }
}