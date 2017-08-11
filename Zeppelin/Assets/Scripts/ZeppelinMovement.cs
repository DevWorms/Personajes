using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinMovement:MonoBehaviour {

    public Animator anim;
    public Transform Zeppelin;
    public float velocidad;

    public int dmg = 20;


    private void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        
        if (Input.GetKey("d"))
        {
            Zeppelin.Translate((velocidad * new Vector2(2, 0)) * Time.deltaTime);
            
        }
        else if (Input.GetKey("a")) {
            Zeppelin.Translate(velocidad * new Vector2(-3, 0)*Time.deltaTime);

        }
	}

    public void Damage(int dmg) {

        anim.SetInteger("life", anim.GetInteger("life") - dmg);
        anim.SetTrigger("Damage");

        int num = anim.GetInteger("life");
        if ( num < 1) {
            anim.SetLayerWeight(0, 0);
            anim.SetTrigger("Dead");
            
        }
       
    
       

    }

    



}
