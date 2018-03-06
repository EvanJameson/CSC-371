using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	string currentLevel;

	public GameObject sewer1, sewer2, sewer3, sewer4, sewer5;
	public GameObject city1, city2, city3, city4, city5;
	public GameObject jungle1, jungle2, jungle3, jungle4, jungle5;

	// Use this for initialization
	void Start () {
		currentLevel = PlayerPrefs.GetString ("LevelAccess");
		switch(currentLevel)
		{
		case "1 - 1":
			sewer1.SetActive (true);
			break;
		case "1 - 2":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			break;
		case "1 - 3":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			break;
		case "1 - 4":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			break;
		case "1 - 5":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			sewer5.SetActive (true);
			break;

			//--sewer zone//
		
		case "2 - 1":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			sewer5.SetActive (true);
			city1.SetActive (true);
			break;
		case "2 - 2":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			sewer5.SetActive (true);
			city1.SetActive (true);
			city2.SetActive (true);
			break;
		case "2 - 3":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			sewer5.SetActive (true);
			city1.SetActive (true);
			city2.SetActive (true);
			city3.SetActive (true);
			break;
		case "2 - 4":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			sewer5.SetActive (true);
			city1.SetActive (true);
			city2.SetActive (true);
			city3.SetActive (true);
			city4.SetActive (true);
			break;
		case "2 - 5":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			sewer5.SetActive (true);
			city1.SetActive (true);
			city2.SetActive (true);
			city3.SetActive (true);
			city4.SetActive (true);
			city5.SetActive (true);
			break;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
