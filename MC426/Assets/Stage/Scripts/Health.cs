using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int total;

    public int Damage(int amount)
    {
        total -= amount;
        if (total <= 0)
            Destroy(gameObject);
        return total;
    }
}