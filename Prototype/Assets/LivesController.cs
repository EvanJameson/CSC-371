using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	private const float IMMUNITY_TIME = 1.0f;

	private int index; //#lives - 1
	private float timeSinceLastLostLife = 0;

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
		if (Time.time - timeSinceLastLostLife > IMMUNITY_TIME) {
			lives [index].SetActive (false);
			index--;
			timeSinceLastLostLife = Time.time;
			PlayerPrefs.SetInt ("lives", index + 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
