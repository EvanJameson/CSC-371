using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	private int index; //#lives - 1

	public GameObject[] lives = new GameObject[5];

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("lives", 5);
		index = PlayerPrefs.GetInt ("lives") - 1;
	}

	public void addLife()
	{
		lives [index].SetActive (true);
		index++;
	}

	public void removeLife()
	{
		lives [index].SetActive (false);
		index--;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
