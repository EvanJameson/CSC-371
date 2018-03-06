using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour {

	private Vector3 offset = Vector3.zero;
	private bool followCamera = false;
	private bool animateIn = false;
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas = Object.FindObjectOfType<Canvas> ();
	}
	
	void Update () {
		if (followCamera) {
			transform.position = CharacterControl.instance.player.transform.position + offset;
		}
		if (animateIn) {
			if (transform.localScale.x < 0.7f) {
				transform.RotateAround (transform.position, new Vector3 (0, 0, 1), -24.0f);
				transform.localScale += new Vector3 (0.05f, 0.05f, 0.05f);
			} else {
				canvas.SendMessage ("RenderPaper", gameObject);
				animateIn = false;
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!followCamera && other.CompareTag ("Player")) {
			offset = transform.position - CharacterControl.instance.player.transform.position;
			followCamera = true;
			animateIn = true;
		}
	}

}
