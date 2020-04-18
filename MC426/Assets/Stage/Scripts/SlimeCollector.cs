using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollector : MonoBehaviour {
    
	public static int score = 100;

    void OnMouseDown() {
		score += 10;
		Destroy(gameObject);
    }
}
