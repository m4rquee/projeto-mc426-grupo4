using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollector : MonoBehaviour {
<<<<<<< HEAD
    [SerializeField]
	private int cashValue;

    public static int cash = 100;

    void OnMouseDown() {
        cash += cashValue;
=======
    
	public static int cash = 100;

    void OnMouseDown() {
        cash += 10;
>>>>>>> master
        Destroy(gameObject);
    }
}
