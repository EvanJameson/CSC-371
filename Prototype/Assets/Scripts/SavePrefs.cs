using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Evan Jameson
public class SavePrefs : MonoBehaviour {



	string lvlKey = "LevelAccess";
	string first;
	private GameObject abilityPanel;
	private GameObject characterPanel;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("lives",5);
		print (PlayerPrefs.GetInt("lives"));
		first = PlayerPrefs.GetString(lvlKey,"1 - 1");
		if(first == "1 - 1")
		{

			PlayerPrefs.SetString (lvlKey, "1 - 1");
		}
		print (PlayerPrefs.GetString(lvlKey));
		//only sets on first run
		//PlayerPrefs.DeleteAll();
		abilityPanel = GameObject.Find("AbilityPanel");
		characterPanel = GameObject.Find("CharacterPanel");
		abilityPanel.SetActive (false);
		characterPanel.SetActive (false);
		/*first = PlayerPrefs.GetString(lvlKey,"1 - 1");

		if(first == "1 - 1")
		{
			
			PlayerPrefs.SetString (lvlKey, "1 - 1");
		}*/

		//everytime you enter main menu lives resets

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
