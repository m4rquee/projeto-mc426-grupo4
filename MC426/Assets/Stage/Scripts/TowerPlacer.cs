using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    private GameObject tower;
    private ItemHighlight itemHighlight;

    public void Start()
    {
        itemHighlight = GetComponent<ItemHighlight>();
    }

    public void OnMouseDown()
    {
        if (tower != null) return;
        tower = Instantiate(TowerSelector.Prefab, transform.position, Quaternion.identity);
        itemHighlight.Toggle();
    }
}