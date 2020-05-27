using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
<<<<<<< HEAD
	[SerializeField]
	private int total;
=======

	[SerializeField]
	private int total = 5;
>>>>>>> master

    public int damage(int amount) {
		total -= amount; 
		if (total <= 0)
			Destroy(gameObject);
		return total;
    }
}
