using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{

    private void OnMouseUpAsButton()
    {
        if (BuildMenu.Cur != null)
        {
            Instantiate(BuildMenu.Cur.gameObject, transform.position, Quaternion.identity);
            SlimeCollector.cash -= BuildMenu.Cur.price;
            BuildMenu.Cur = null;
        }
    }
}
