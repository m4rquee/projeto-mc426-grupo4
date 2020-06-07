using UnityEngine;

public class SlimeCollector : MonoBehaviour
{
    [SerializeField] private int cashValue;
    
    private void OnMouseDown()
    {
        BuildMenu.Cash += cashValue;
        Destroy(gameObject);
    }
}