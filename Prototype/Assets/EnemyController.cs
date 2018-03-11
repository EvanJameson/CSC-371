using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private bool isdead = false;
	private bool attack = false;
	private Rigidbody2D rb;
	private float bird_speed = 3f;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player") && Input.GetButtonDown("Fire1")) {
			isdead = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("player dead");
		}
	}

	void Attack() {
		attack = true;
	}

	void Update() {
		if (isdead) {
			rb.velocity = Vector2.zero;
			rb.AddTorque (100.0f);
			gameObject.transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
			if (gameObject.transform.localScale.x <= 0.001f) {
				Destroy (gameObject);
			}
		} else if (attack) {
			Vector2 v = CharacterControl.instance.player.transform.position - rb.transform.position;
			v.Normalize ();
			rb.velocity = v * bird_speed;
			rb.transform.rotation = new Quaternion (0, 0, Mathf.PI / 3f - Mathf.Atan (v.x / v.y), 1);
		}
	}
}
