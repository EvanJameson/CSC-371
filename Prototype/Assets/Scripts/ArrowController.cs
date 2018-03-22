//Author: Evan Jameson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	private float y0;
	private float amplitude = .4f;
	private int speed = 5;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		y0 = transform.position.y;
		x = transform.position.x;
		y = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position =new Vector3(x, y0 + amplitude * Mathf.Sin (speed * Time.time),0);
	}

}
