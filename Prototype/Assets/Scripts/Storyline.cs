using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storyline : MonoBehaviour {

	public GameObject paper;
	public GameObject expandedBackground;

	private GameObject activePaper;
	private List<GameObject> papersCollected = new List<GameObject>();
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas = Object.FindObjectOfType<Canvas> ();
	}

	void RenderPaper(Sprite papersprite) {
		activePaper = Instantiate (paper);
		activePaper.transform.SetParent(gameObject.transform, false);

		activePaper.GetComponent<Image> ().sprite = papersprite;
		papersCollected.Add(activePaper);
	}

	void ExpandJournalUI() {
		Vector3 current = new Vector3(200, canvas.pixelRect.height - 200, 0);
		for (int i = 0; i < papersCollected.Count; i++) {
			papersCollected [i].SendMessage ("MoveTo", current);
			current.x += 150;
		}
		ActivatePauseBackground ();
	}

	void AnimateOut() {
		activePaper.SendMessage ("AnimateOut");
	}

	void Exit() {
		RemovePauseBackground ();
		for (int i = 0; i < papersCollected.Count; i++) {
			papersCollected [i].SendMessage ("ReturnInactive");
		}
	}

	void RemovePauseBackground() {
		Time.timeScale = 1;
		expandedBackground.SetActive (false);
	}

	void ActivatePauseBackground() {
		Time.timeScale = 0;
		expandedBackground.SetActive (true);
	}

	void RestoreOtherPages() {
		for (int i = 0; i < papersCollected.Count; i++) {
			papersCollected [i].SetActive(true);
		}
	}

	void RemoveOtherPages(GameObject p) {
		for (int i = 0; i < papersCollected.Count; i++) {
			if (papersCollected[i] != p) {
				papersCollected [i].SetActive(false);
			}
		}
	}
}
