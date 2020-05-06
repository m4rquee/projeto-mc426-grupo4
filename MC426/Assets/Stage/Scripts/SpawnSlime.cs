using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int delay = 10;

    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    private void Spawn()
    {
        var aux = Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(aux, 5);
    }
}
