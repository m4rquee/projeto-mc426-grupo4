using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    public GameObject prefab;

    [SerializeField]
    public string monsterTag;

    public float interval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",0,interval);
    }

    private void Shoot(){
        // if (virusInFront()){}
        if (true){
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

    private bool virusInFront(){
        Vector2 origin = new Vector2(9.5f, transform.position.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, -Vector2.right);

        foreach(RaycastHit2D hit in hits) {
            if(hit.collider != null && hit.collider.tag == monsterTag){
                return true;
            }
        }
        return false;
    }
}
