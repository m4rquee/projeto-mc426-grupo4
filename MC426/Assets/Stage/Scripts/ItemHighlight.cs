using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour {
    
    [SerializeField]
<<<<<<< HEAD
    private Color startColor = Color.clear;
    [SerializeField]
    private Color highlightedColor = Color.gray;

    private Renderer render;
    private bool active = true;

	void Start() {
		render = GetComponent<Renderer>();
		render.material.color = startColor;
	}

	void OnMouseEnter() {
		if (active && BuildMenu.cur != null)
			render.material.color = highlightedColor;
	}

	void OnMouseExit() {
		Clear();
	}

	void Clear() {
		render.material.color = startColor;
	}

	public void Toggle() {
		active = !active;
		Clear();
=======
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
>>>>>>> master
	}
}
