using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Manager : MonoBehaviour {

    public static bool isStart = false;

    public GameObject tutorialScreen;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
        {
            Time.timeScale = 1;
            tutorialScreen.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Sewer1");
        }
    }
}
