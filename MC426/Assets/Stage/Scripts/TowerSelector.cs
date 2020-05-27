using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

<<<<<<< HEAD
    [SerializeField]
    private GameObject aux;
    public static GameObject prefab;
=======
    public static GameObject prefab;
    [SerializeField]
    private GameObject aux;
>>>>>>> master

    void OnMouseDown() {
        prefab = aux;
    }

<<<<<<< HEAD
    void Start() {
        prefab = aux;
    }
=======
    //void Start() {
    //    prefab = aux;
    //}
>>>>>>> master
}
