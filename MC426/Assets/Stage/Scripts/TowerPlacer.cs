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
        CreateTower();
    }

    public GameObject CreateTower() 
    {
        if (BuildMenu.Cur == null || tower != null) return null;
        tower = Instantiate(BuildMenu.Cur.gameObject, transform.position, Quaternion.identity);
        BuildMenu.Cash -= BuildMenu.Cur.price;
        BuildMenu.Cur = null;
        itemHighlight.Toggle();
        return tower;
    }
}