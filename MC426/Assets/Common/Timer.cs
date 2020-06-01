using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] private uint tickRate = 1;

    private delegate void DelayedTick(uint currentTime);

    public delegate void Tick();

    private static event DelayedTick Listeners;

    private static Dictionary<Tick, DelayedTick> _mapper; //TODO: Remove this

    private void OnEnable()
    {
        _mapper = new Dictionary<Tick, DelayedTick>();
        StartCoroutine(Clock());
    }

    private IEnumerator Clock()
    {
        uint currentTime = 0;
        while (enabled)
        {
            yield return new WaitUntil(() => Listeners != null); // Stop the clock if there is no lister
            Listeners?.Invoke(currentTime);
            // Debug.Log("Clock - Tick");
            yield return new WaitForSeconds(tickRate);
            currentTime += tickRate;
        }
    }

    public static void Subscribe(Tick callback, uint delay)
    {
        DelayedTick delayedCallback = currentTime =>
        {
            if (currentTime % delay != 0) return;
            callback();
            Debug.Log(delay);
        };
        Listeners += delayedCallback;
        _mapper[callback] = delayedCallback;
    }

    public static void Unsubscribe(Tick callback)
    {
        Listeners -= _mapper[callback];
        _mapper.Remove(callback);
    }
}