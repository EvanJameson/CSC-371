using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Audio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Pause("Today");
        FindObjectOfType<AudioManager>().Pause("Times");
        FindObjectOfType<AudioManager>().Play("Tomorrow");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
