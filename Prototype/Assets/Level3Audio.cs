using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Audio : MonoBehaviour {

    public AudioManager audioSource;

	// Use this for initialization
	void Start () {
        audioSource = AudioManager.GetInstance();
        audioSource.Pause("Today");
        audioSource.Pause("Times");
        audioSource.Play("Tomorrow");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
