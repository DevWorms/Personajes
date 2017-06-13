using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Animator anim;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("caminandoDer", true);
            anim.SetBool("isIddle", false);

        }
        else
        {
            anim.SetBool("caminandoDer", false);
            anim.SetBool("isIddle", true);
        }
    }
}
