using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	public GameObject bird;

	private Vector3 offset = new Vector3 (10.0f, 5.0f, 0f);

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			StartBirdAttack ();
		}
	}

	void StartBirdAttack() {
		bird.SendMessage ("Attack");
		//Instantiate (bird, gameObject.transform.position + offset, gameObject.transform.rotation);
	}

}
