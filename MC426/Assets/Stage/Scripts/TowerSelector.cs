using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] private GameObject aux;
    public static GameObject Prefab;

    public void OnMouseDown()
    {
        Prefab = aux;
    }

    private void Start()
    {
        Prefab = aux;
    }
}