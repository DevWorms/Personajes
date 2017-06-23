using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloboCamina : MonoBehaviour {
    public GameObject StartPoint;
    public GameObject EndPoint;
    public float EnemySpeed;
    private bool GoRight;

	// Use this for initialization
	void Start () {
		if (!GoRight)
        {
            transform.position = StartPoint.transform.position;
        }
        else
        {
            transform.position = EndPoint.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(!GoRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, EnemySpeed * Time.deltaTime);
            if (transform.position == EndPoint.transform.position)
            {
                GoRight = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if(GoRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPoint.transform.position, EnemySpeed * Time.deltaTime);
            if(transform.position == StartPoint.transform.position)
            {
                GoRight = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
	}
}
