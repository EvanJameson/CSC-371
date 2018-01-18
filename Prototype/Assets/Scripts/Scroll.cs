using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public float speed = 0.05f;
	private Renderer rd;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed, Time.time * speed);
		rd.material.mainTextureOffset = offset;
	}
}
