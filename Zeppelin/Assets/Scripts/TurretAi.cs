using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAi : MonoBehaviour {


    public float distance;
    public float rango;
    public float intervaloDisparos;
    public float balaSpeed = 100;
    public float balaTimer;


    public bool ataca = false;
    public bool lookingRight = true;

    public GameObject bala;
    public Transform objetivo;
    public Animator anim;
    public Transform shootPointLeft;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        RangeCheck();
    }

    void RangeCheck() {
        distance = Vector3.Distance(transform.position, objetivo.transform.position);

        if (distance < rango) {
            ataca = true;
        }
        if (distance > rango) {
            ataca = false;
        }
    }

    public void Attack(bool AttackingRight) {
        balaTimer += Time.deltaTime;
        
        if (balaTimer >= intervaloDisparos) {
            Vector2 direction = objetivo.transform.position - transform.position;
            direction.Normalize();

            if (!AttackingRight) {
                GameObject balaClone;
                balaClone = Instantiate(bala, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                balaClone.GetComponent<Rigidbody2D>().velocity = direction * balaSpeed;

                balaTimer = 0;
            }

        }
    }

}
