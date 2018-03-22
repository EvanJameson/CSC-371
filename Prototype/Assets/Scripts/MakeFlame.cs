using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Pradeep Sangli
public class MakeFlame : MonoBehaviour {
	private float InstantiationTimer = 4f;
	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAndDestroy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(2);
		Destroy (gameObject);	
	}


		

		



}
