using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

	private void OnMouseUpAsButton() {
		if (BuildMenu.cur != null){
			Instantiate(BuildMenu.cur.gameObject, transform.position, Quaternion.identity);
			SlimeCollector.cash -= BuildMenu.cur.price;
			BuildMenu.cur = null;
		}
	}
}
