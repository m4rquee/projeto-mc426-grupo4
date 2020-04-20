using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour {
    
    [SerializeField]
    private Color startColor = Color.green;
    [SerializeField]
    private Color highlightedColor = Color.gray;

	void Start() {
		GetComponent<Renderer>().material.color = startColor;
	}

	void OnMouseEnter() {
		GetComponent<Renderer>().material.color = highlightedColor;
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = startColor;
	}
}
