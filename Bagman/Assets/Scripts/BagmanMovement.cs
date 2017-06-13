using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagmanMovement : MonoBehaviour {

    public Animator anim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            
        if (Input.GetKey("d"))
        {
            anim.SetBool("caminandoDer", true);
            anim.SetBool("isIddle", false);
            anim.SetBool("jumping", false);
            anim.SetBool("isAtacking", false);
        }
        else if (Input.GetKey("w"))
        {
            anim.SetBool("jumping", true);
            anim.SetBool("caminandoDer", false);
            anim.SetBool("isIddle", false);
            anim.SetBool("isAtacking", false);
        }
        else if (Input.GetKey("space"))
        {
            anim.SetBool("jumping", false);
            anim.SetBool("caminandoDer", false);
            anim.SetBool("isIddle", false);
            anim.SetBool("isAtacking", true);
        }
        else
        {
            anim.SetBool("caminandoDer", false);
            anim.SetBool("isIddle", true);
            anim.SetBool("jumping", false);
            anim.SetBool("isAtacking", false);
        }
        
    }
}
