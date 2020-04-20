using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour {
    
    [SerializeField]
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
		if (active)
			render.material.color = highlightedColor;
	}

	void OnMouseExit() {
		render.material.color = startColor;
	}

	public void Toggle() {
		active = !active;
	}
}
