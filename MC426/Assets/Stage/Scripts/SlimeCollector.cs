using UnityEngine;

public class SlimeCollector : MonoBehaviour
{
    [SerializeField] private int cashValue;
    public static int Cash = 100;

    private void OnMouseOver()
    {
        Cash += cashValue;
        Destroy(gameObject);
    }
}