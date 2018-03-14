using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Audio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Pause("Today");
        FindObjectOfType<AudioManager>().Pause("Tomorrow");
        FindObjectOfType<AudioManager>().Play("Times");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
