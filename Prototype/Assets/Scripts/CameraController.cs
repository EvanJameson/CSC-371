using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//https://answers.unity.com/questions/174002/what-is-the-relationship-between-camera-size-units.html
		//believe this is so things will scale correctly if the resolution is changed, not sure
		offset = transform.position - player.transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
