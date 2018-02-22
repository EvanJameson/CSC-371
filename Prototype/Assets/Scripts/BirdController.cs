using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	private Rigidbody2D rb;
	private bool attack = false;
	private float bird_speed = 5f;

	void Start() {
		rb = GetComponentInChildren<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			StartBirdAttack ();
		}
	}

	void StartBirdAttack() {
		attack = true;
	}

	void Update() {
		if (attack) {
			Vector2 v = CharacterControl.instance.player.transform.position - rb.transform.position;
			v.Normalize ();
			rb.velocity = v * bird_speed;
			rb.transform.rotation = new Quaternion (0, 0, Mathf.PI/3f - Mathf.Atan(v.x / v.y), 1);
		}
	}
}
