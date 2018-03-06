using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storyline : MonoBehaviour {

	public GameObject paper;
	public GameObject xbutton;

	private GameObject activePaper;
	private List<GameObject> papersCollected = new List<GameObject>();
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void RenderPaper(GameObject paperO) {
		activePaper = Instantiate (paper);
		activePaper.transform.SetParent(gameObject.transform, false);

		activePaper.GetComponent<Image> ().sprite = paperO.GetComponent<SpriteRenderer>().sprite;
		xbutton.SetActive (true);
		papersCollected.Add(activePaper);
	}

	void AnimateOut() {
		activePaper.SendMessage ("AnimateOut");
	}

	void RemoveXButton() {
		xbutton.SetActive (false);
	}
}
