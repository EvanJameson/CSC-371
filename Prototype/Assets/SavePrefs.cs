using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour {

	string lvlKey = "LevelAccess";
	string first;

	// Use this for initialization
	void Start () {
		//only sets on first run
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
