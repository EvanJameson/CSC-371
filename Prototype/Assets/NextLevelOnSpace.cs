using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelOnSpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			GameObject.Find("LevelCompletedTrigger").SendMessage("FinishLevel");
		}
	}
}
