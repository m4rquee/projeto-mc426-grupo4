using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int delay = 10;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), delay, delay);
    }

    private void Spawn()
    {
        Destroy(Instantiate(prefab, transform), 5);
    }
}