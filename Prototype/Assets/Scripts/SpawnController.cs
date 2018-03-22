using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Evan Jameson

public class SpawnController : MonoBehaviour {

	GameObject player;
	bool spawned = false; //so this only runs once

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null)
		{
			player = GameObject.Find ("RatPlayer(Clone)");
		}
		if(player != null && !spawned)
		{
			Transform tf;
			tf = player.GetComponent<Transform> ();
			tf.position = gameObject.GetComponent<Transform> ().position;
			spawned = true;
		}
	}
}
