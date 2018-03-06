using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour {



	string lvlKey = "LevelAccess";
	string first;
	private GameObject abilityPanel;
	private GameObject characterPanel;

	// Use this for initialization
	void Start () {
		//only sets on first run
		//PlayerPrefs.DeleteAll();
		abilityPanel = GameObject.Find("AbilityPanel");
		characterPanel = GameObject.Find("CharacterPanel");
		abilityPanel.SetActive (false);
		characterPanel.SetActive (false);
		first = PlayerPrefs.GetString(lvlKey,"1 - 1");

		if(first == "1 - 1")
		{
			
			PlayerPrefs.SetString (lvlKey, "1 - 1");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
