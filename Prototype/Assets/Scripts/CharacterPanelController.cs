using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Authors: Tori
public class CharacterPanelController : MonoBehaviour {

	private int rat = 0, cat = 1, monkey = 2;
	private string mystery = "MysteryContainer";
	private string overlay = "ContainerOverlay";

	void Start () {
		if (transform.childCount == 3) {
			if (PlayerPrefs.GetInt("hasCat") == 1) {
				transform.GetChild(cat).Find(mystery).gameObject.SetActive(false);
			}
			if (PlayerPrefs.GetInt("hasMonkey") == 1) {
				transform.GetChild(monkey).Find(mystery).gameObject.SetActive(false);
			}
		} else {
			Debug.Log("Found wrong number of character panel boxes - CharacterPanelController");
		}
	}
	
	void SwapCharacter (int choice) {
		setOverlay(choice, false);
		setOverlay((choice + 1) % 3, true);
		setOverlay((choice + 2) % 3, true);
	}

	void setOverlay(int child, bool active) {
		transform.GetChild(child).Find(overlay).gameObject.SetActive(active);
	}
}
