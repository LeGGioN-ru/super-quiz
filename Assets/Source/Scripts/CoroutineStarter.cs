using System;
using System.Collections;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
    public void StartWithDelay(float delay, Action action)
    {
        StartCoroutine(DelayStarting(delay, action));
    }

    private IEnumerator DelayStarting(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);

        action?.Invoke();
    }
}
