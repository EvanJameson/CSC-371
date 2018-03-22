using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Authors: Nick Sciacqua
public class syringeScript : MonoBehaviour {

	public int speed = 6;
	// Use this for initialization
	void Start () {
		Rigidbody2D r2d = GetComponent<Rigidbody2D> ();
		r2d.velocity = new Vector2 (0, -speed);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		Destroy (gameObject);
	}
}
