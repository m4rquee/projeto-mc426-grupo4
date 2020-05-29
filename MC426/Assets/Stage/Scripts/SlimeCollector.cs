using UnityEngine;

public class SlimeCollector : MonoBehaviour
{
    public static int Cash = 100;

    private void OnMouseDown()
    {
        Cash += 10;
        Destroy(gameObject);
    }
}