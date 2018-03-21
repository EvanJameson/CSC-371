using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour {

	private Canvas canvas;
	private bool firsttime = true;

	//access script in the trigger to decrement page value
	private GameObject levelCompletedTrigger;
	private CompleteLevel cl;

	// Use this for initialization
	void Start () {
		canvas = Object.FindObjectOfType<Canvas> ();
		levelCompletedTrigger = GameObject.Find("LevelCompletedTrigger");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player") && firsttime) {
			firsttime = false;

			//decrement pages left
			cl = levelCompletedTrigger.GetComponent<CompleteLevel> ();
			cl.pagesGot++;
			canvas.SendMessage("RenderPaper", gameObject.GetComponent<SpriteRenderer>().sprite);
			Destroy(gameObject);
		}
	}

}
