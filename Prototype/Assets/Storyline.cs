using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyline : MonoBehaviour {

	public GameObject paper;
	public GameObject xbutton;

	private GameObject activePaper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RenderPaper() {
		paper.SetActive (true);
		xbutton.SetActive (true);
		activePaper = paper;
	}

	void AnimateOut() {
		activePaper.SendMessage ("AnimateOut");
	}

	void RemoveXButton() {
		xbutton.SetActive (false);
	}
}
