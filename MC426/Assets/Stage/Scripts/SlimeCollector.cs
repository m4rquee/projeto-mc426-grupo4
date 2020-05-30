using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollector : MonoBehaviour {
    [SerializeField]
	private int cashValue;

    public static int cash = 100;

    void OnMouseDown() {
        cash += cashValue;
        Destroy(gameObject);
    }
}
