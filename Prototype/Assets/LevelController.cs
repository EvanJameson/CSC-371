using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	string currentLevel;

	public GameObject sewer1, sewer2, sewer3, sewer4;
	public Text s1, s2, s3, s4;

	public GameObject city1, city2, city3, city4, city5;
	public Text c1, c2, c3, c4, c5;

	public GameObject jungle1, jungle2, jungle3, jungle4, jungle5;
	public Text j1, j2, j3, j4, j5;

	// Use this for initialization
	void Start () {
		currentLevel = PlayerPrefs.GetString ("LevelAccess");
		updateGrades ();
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
		

			//--sewer zone//
		
		case "2 - 1":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			city1.SetActive (true);
			break;
		case "2 - 2":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			city1.SetActive (true);
			city2.SetActive (true);
			break;
		case "2 - 3":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
			city1.SetActive (true);
			city2.SetActive (true);
			city3.SetActive (true);
			break;
		case "2 - 4":
			sewer1.SetActive (true);
			sewer2.SetActive (true);
			sewer3.SetActive (true);
			sewer4.SetActive (true);
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

	void updateGrades()
	{
		s1.text += "  " + PlayerPrefs.GetString ("1 - 1");
		s2.text += "  " + PlayerPrefs.GetString ("1 - 2");
		s3.text += "  " + PlayerPrefs.GetString ("1 - 3");
		s4.text += "  " + PlayerPrefs.GetString ("1 - 4");

		c1.text += "  " + PlayerPrefs.GetString ("2 - 1");
		c2.text += "  " + PlayerPrefs.GetString ("2 - 2");
		c3.text += "  " + PlayerPrefs.GetString ("2 - 3");
		c4.text += "  " + PlayerPrefs.GetString ("2 - 4");
		c5.text += "  " + PlayerPrefs.GetString ("2 - 5");

		j1.text += "  " + PlayerPrefs.GetString ("3 - 1");
		j2.text += "  " + PlayerPrefs.GetString ("3 - 2");
		j3.text += "  " + PlayerPrefs.GetString ("3 - 3");
		j4.text += "  " + PlayerPrefs.GetString ("3 - 4");
		j5.text += "  " + PlayerPrefs.GetString ("3 - 5");
	}
}
