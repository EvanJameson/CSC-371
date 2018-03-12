using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckController : MonoBehaviour {

	public bool touching = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionStay2D (Collider2D other)
	{
		touching = true;
	}

	public void OnCollisionExit2D (Collider2D other)
	{
		touching = false;
	}
}
