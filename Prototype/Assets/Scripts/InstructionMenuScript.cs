using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionMenuScript : MonoBehaviour {

	void Start () {
		Time.timeScale = 0;
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Time.timeScale = 1;
			Destroy(gameObject);
		}
	}
}
