using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Virus"){
            col.GetComponent<Health>().damage(1);
            Destroy (gameObject);
        }
    }
}
