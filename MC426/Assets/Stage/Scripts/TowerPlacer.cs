using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

	private GameObject tower = null;

    void OnMouseDown() {
    	if (tower == null && TowerSelector.prefab != null)
        	tower = Instantiate(TowerSelector.prefab, transform.position, Quaternion.identity);
    }
}
