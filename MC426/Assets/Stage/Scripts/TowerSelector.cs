using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

    public static GameObject prefab;
    [SerializeField]
    private GameObject aux;

    void Start() {
        prefab = aux;
    }
}
