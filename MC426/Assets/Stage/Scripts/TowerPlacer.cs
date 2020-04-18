using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

    void OnMouseDown() {
        Instantiate(TowerSelector.prefab, transform.position, Quaternion.identity);
    }
}
