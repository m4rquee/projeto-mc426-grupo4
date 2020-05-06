using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollector : MonoBehaviour
{

    public static int cash = 100;

    void OnMouseDown()
    {
        cash += 10;
        Destroy(gameObject);
    }
}
