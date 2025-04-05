using System.Collections;
using UnityEngine;

namespace CustomUtilities
{
    public class CoroutineManager : MonoBehaviour
    {
        public Coroutine StartRoutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void FinishRoutine(Coroutine routine)
        {
            StopCoroutine(routine);
        }
    }
}