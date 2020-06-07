using UnityEngine;

public class DefaultVelocity : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}