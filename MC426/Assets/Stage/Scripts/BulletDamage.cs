using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField]
    public int damageDone;
    public string monsterTag;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == monsterTag){
            col.GetComponent<Health>().damage(damageDone);
            Destroy (gameObject);
        }
    }
}
