using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] public int damageDone;
    public string monsterTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(monsterTag)) return;
        col.GetComponent<Health>().damage(damageDone);
        Destroy(gameObject);
    }
}
