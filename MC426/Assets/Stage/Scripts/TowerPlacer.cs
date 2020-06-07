using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    private GameObject tower;
    private ItemHighlight itemHighlight;

    public void Start()
    {
        itemHighlight = GetComponent<ItemHighlight>();
    }

    private void OnMouseUpAsButton()
    {
        if (BuildMenu.Cur == null || tower != null) return;
        tower = Instantiate(BuildMenu.Cur.gameObject, transform.position, Quaternion.identity);
        SlimeCollector.Cash -= BuildMenu.Cur.price;
        BuildMenu.Cur = null;
        itemHighlight.Toggle();
    }
}