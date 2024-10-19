using System.Collections;
using UnityEngine;

namespace DangerCity.Infrastructure.LifeCycle
{
    public interface ICoroutineRunner
    {
        Coroutine RunCoroutine(IEnumerator routine);
        void AbortCoroutine(IEnumerator routine);
        void AbortCoroutine(Coroutine routine);
    }
}