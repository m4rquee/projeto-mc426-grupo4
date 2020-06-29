using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private uint delay = 10;
    [SerializeField] private int slimeLifetime = 5;

    private void OnEnable()
    {
        Timer.Subscribe(Spawn, delay);
    }

    public void OnDisable()
    {
        Timer.Unsubscribe(Spawn);
    }

    private void Spawn()
    {
        Destroy(Instantiate(prefab, transform.position, Quaternion.identity), slimeLifetime);
    }
}