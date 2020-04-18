using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private int total = 5;

    public int damage(int amount) {
		total -= amount; 
		if (total <= 0)
			Destroy(gameObject);
		return total;
    }
}
