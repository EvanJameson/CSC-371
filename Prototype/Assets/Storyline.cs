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
	private Vector3 firstPosition = new Vector3(80, 400, 0);

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
		papersCollected.Add(activePaper);
	}

	void ExpandJournalUI() {
		Vector3 current = firstPosition;
		for (int i = 0; i < papersCollected.Count; i++) {
			papersCollected [i].SendMessage ("MoveTo", current);
			current.x += 80;
		}
		ActivateXButton ();
	}

	void AnimateOut() {
		activePaper.SendMessage ("AnimateOut");
	}

	void Exit() {
		RemoveXButton ();
		for (int i = 0; i < papersCollected.Count; i++) {
			papersCollected [i].SendMessage ("ReturnInactive");
		}
	}

	void RemoveXButton() {
		xbutton.SetActive (false);
	}

	void ActivateXButton() {
		xbutton.SetActive (true);
	}
}
