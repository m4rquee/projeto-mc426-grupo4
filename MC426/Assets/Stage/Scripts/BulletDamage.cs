using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField]
    public int damageDone;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Virus"){
            col.GetComponent<Health>().damage(damageDone);
            Destroy (gameObject);
        }
    }
}
