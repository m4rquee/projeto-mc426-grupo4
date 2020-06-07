using UnityEngine;

public class SlimeCollector : MonoBehaviour
{
    [SerializeField] private int cashValue;

    private void OnMouseOver()
    {
        BuildMenu.Cash += cashValue;
        Destroy(gameObject);
    }
}