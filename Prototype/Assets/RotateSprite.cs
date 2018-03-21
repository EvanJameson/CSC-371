using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour {

	private float maxRot;
	private float direction = 0.1f;

	void Start () {
		maxRot = transform.localScale.x;
	}
	
	void Update () {
		if (transform.localScale.x > maxRot || transform.localScale.x < -maxRot) {
			direction *= -1;
		}
		transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * direction, transform.localScale.y, transform.localScale.z);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			GameObject.Find("Lives").GetComponent<LivesController>().addLife();
			Destroy(gameObject);
		}
	}
}
