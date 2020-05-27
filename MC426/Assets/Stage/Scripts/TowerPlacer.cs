using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

<<<<<<< HEAD
	private void OnMouseUpAsButton() {
		if (BuildMenu.cur != null){
			Instantiate(BuildMenu.cur.gameObject, transform.position, Quaternion.identity);
			SlimeCollector.cash -= BuildMenu.cur.price;
			BuildMenu.cur = null;
		}
	}
=======
	private GameObject tower = null;

    void OnMouseDown() {
        if (tower == null && TowerSelector.prefab != null) {
            tower = Instantiate(TowerSelector.prefab, transform.position, Quaternion.identity);
            var position = tower.transform.position;
            position.z = 1;
            tower.transform.position = position;
        }
    }
>>>>>>> master
}
