using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

	string progress;
	public string nextLevel;

	int progressIndex;
	int nextIndex;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			progress = PlayerPrefs.GetString ("LevelAccess");
			progressIndex = SceneManager.GetSceneByName (progress).buildIndex;
			nextIndex = SceneManager.GetSceneByName (nextLevel).buildIndex;

			//so if you have progressed further and go backwards it doesnt reset progress
			//pipes tho
			if(progressIndex <= nextIndex)
			{
				PlayerPrefs.SetString ("LevelAccess", nextLevel);
			}
			SceneManager.LoadScene (nextLevel);
		}
	}
}
