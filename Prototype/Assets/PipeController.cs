﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public GameObject Arrow;
	private Transform tf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Arrow.SetActive (true);
		}
		if(Input.GetButtonDown("Jump"))
		{
			tf = other.gameObject.GetComponent<Transform> ();
			tf.position += new Vector3 (2.5f,0,0); 
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Arrow.SetActive (false);
		}

	}
}
