using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Audio : MonoBehaviour {

    public AudioManager audioSource;

	// Use this for initialization
	void Start () {
        audioSource = AudioManager.GetInstance();
        audioSource.Pause("Today");
        audioSource.Pause("Tomorrow");
        audioSource.Play("Times");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
