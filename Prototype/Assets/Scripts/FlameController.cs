using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Pradeep Sangli
public class FlameController : MonoBehaviour {

	public GameObject flame;
	public GameObject flamePosition01;
	// Use this for initialization
	void Start () {
		StartCoroutine (fireBB());
	}

	IEnumerator fireBB(){
		yield return new WaitForSeconds (5.0f);
		GameObject fire1 = (GameObject)Instantiate (flame);
		flame.transform.position = flamePosition01.transform.position;
		StartCoroutine (fireBB ());
	}
	// Update is called once per frame
	void Update () {
		
	}
}
