using UnityEngine;

public class ItemHighlight : MonoBehaviour
{
    [SerializeField] private Color startColor = Color.clear;
    [SerializeField] private Color highlightedColor = Color.gray;

    private Renderer render;
    private bool active = true;

    private void Start()
    {
        render = GetComponent<Renderer>();
        render.material.color = startColor;
    }

    private void OnMouseEnter()
    {
        if (active)
            render.material.color = highlightedColor;
    }

    private void OnMouseExit()
    {
        Clear();
    }

    private void Clear()
    {
        render.material.color = startColor;
    }

    public void Toggle()
    {
        active = !active;
        Clear();
    }
}