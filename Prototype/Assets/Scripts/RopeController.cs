using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Authors: Evan Jameson

public class RopeController : MonoBehaviour {

	private HingeJoint2D hj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(Input.GetButtonDown("Fire1") && other.gameObject.CompareTag("Player"))//other.gameObject.CompareTag("Rope") && Input.GetButtonDown("Fire1"))
		{
			other.gameObject.SetActive (false);
			//this.gameObject.SetActive (false);
			hj = other.GetComponent<HingeJoint2D> ();

		}
	}
}
