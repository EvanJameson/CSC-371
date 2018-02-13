using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_1_Manager : MonoBehaviour {

    public static bool isStart = false;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
        {
            Time.timeScale = 1;
        }
	}
}
