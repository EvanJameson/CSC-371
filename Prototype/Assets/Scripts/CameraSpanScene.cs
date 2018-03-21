using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpanScene : MonoBehaviour {
	private GameObject cam;
	public Vector2 location;
	public float scale;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		//Debug.Log("in on trigger");
		cam.SendMessage("SpanScene", new Vector3(location.x, location.y, scale));
		Destroy(gameObject);
	}
}
