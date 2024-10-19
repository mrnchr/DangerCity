using System.Collections;
using UnityEngine;

namespace DangerCity.Infrastructure.LifeCycle
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void AbortCoroutine(IEnumerator routine)
        {
            StopCoroutine(routine);
        }

        public void AbortCoroutine(Coroutine routine)
        {
            StopCoroutine(routine);
        }
    }
}