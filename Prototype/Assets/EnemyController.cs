using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public bool isdead;
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetButtonDown ("Fire1")) {
			rb.AddTorque (1.0f);
			isdead = true;
		}
	}
}
