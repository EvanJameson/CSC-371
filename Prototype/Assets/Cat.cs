﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

	public float forceY = 150f;
	public float forceX = 75f;
	private Rigidbody2D myRigidbody;
	bool isgrounded = false;
	bool hasWaved= false;

    private float myX;

	public GameObject PlayerBulletGO;
	public GameObject PlayerBulletGO2;
	public GameObject shock1;
	public GameObject shock2;

	void Awake(){
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
        myX = transform.position.x;
		StartCoroutine (Jump ());
	}

    private void Update()
    {
        if(transform.position.x != 8.53)
        {
            transform.position = new Vector3(myX, transform.position.y, transform.position.z) ;
        }
    }

    IEnumerator Jump(){
		yield return new WaitForSeconds (Random.Range (3, 10));
		//forceY = Random.Range (250, 400);
		myRigidbody.AddForce (new Vector2 (0, 500f * 1500f));
		hasWaved = false;
		yield return new WaitForSeconds (2.0f);
		GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO);
		bullet01.transform.position = shock1.transform.position;

		GameObject bullet02 = (GameObject)Instantiate (PlayerBulletGO2);
		bullet02.transform.position = shock2.transform.position;

		StartCoroutine (Jump ());
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Box"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    /*
	IEnumerator Move(){
		yield return StartCoroutine (Jump());
		forceX = 75f;
		myRigidbody.AddForce (new Vector2 (forceX, 0));
		//yield return new WaitForSeconds (3.5f);
	}

	// Update is called once per frame
	void Update () {
		if(isgrounded == true){
			if(hasWaved == false){
				StartCoroutine (Move ());
				hasWaved = true;
			}
				
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Floor")){
			isgrounded = true;
		}
	}

*/
}