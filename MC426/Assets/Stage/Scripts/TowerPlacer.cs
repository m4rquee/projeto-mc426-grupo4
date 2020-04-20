using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

	private GameObject tower = null;
	private ItemHighlight itemHighlight;

	void Start() {
		itemHighlight = GetComponent<ItemHighlight>();
	}

    void OnMouseDown() {
    	if (tower == null) {
        	tower = Instantiate(TowerSelector.prefab, transform.position, Quaternion.identity);
        	itemHighlight.Toggle();
    	}
    }
}
