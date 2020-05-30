using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

    [SerializeField]
    private GameObject aux;
    public static GameObject prefab;

    void OnMouseDown() {
        prefab = aux;
    }

    void Start() {
        prefab = aux;
    }
}
