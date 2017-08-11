using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.isTrigger != true) {
            if (col.CompareTag("Zeppelin"))
            {
               col.GetComponent<ZeppelinMovement>().Damage(15);
                
            }
           
            Destroy(gameObject);
        }
        
    }
}
