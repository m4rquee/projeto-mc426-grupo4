using System.Linq;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    public GameObject prefab;

    [SerializeField] public string monsterTag;

    public float interval;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0, interval);
    }

    private void Shoot()
    {
        if (VirusInFront())
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

    //TODO: Simplify this function. Raycast is too over engineered
    private bool VirusInFront()
    {
        Vector2 origin = new Vector2(9.5f, transform.position.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, -Vector2.right);

        return hits.Any(hit => hit.collider != null && hit.collider.CompareTag(monsterTag));
    }
}
