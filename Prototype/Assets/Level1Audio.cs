using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Audio : MonoBehaviour {

    public AudioManager audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = AudioManager.GetInstance();
        audioSource.Pause("Tomorrow");
        audioSource.Pause("Times");
        audioSource.Play("Today");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
