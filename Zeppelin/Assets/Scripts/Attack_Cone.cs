using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {

    public TurretAi turretAi;

    public bool isLeft = false;
     void Awake()
    {
        turretAi = gameObject.GetComponentInParent<TurretAi>();
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
       
        if (col.CompareTag("Zeppelin")) {
         
            if (isLeft)
            {
                turretAi.Attack(false);
            }
            else {
                turretAi.Attack(true);
            }
        }
    }
}
