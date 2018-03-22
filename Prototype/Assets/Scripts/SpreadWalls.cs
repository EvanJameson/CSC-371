using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Authors: Nick Sciacqua
public class SpreadWalls : MonoBehaviour {

	private Transform wall1;
	private Transform wall2;
	// Use this for initialization
	void Start () {
		Transform[] walls = GetComponentsInChildren<Transform> ();
		wall1 = walls [1];
		wall2 = walls [2];
		//phase = GameObject.FindObjectOfType<BossGunnerControl>().phase;

	}
	
	// Update is called once per frame
	public void moveWalls(){
			wall1.Translate(new Vector3(-1.5f,0f,0f));
			wall2.Translate(new Vector3(1.5f,0f,0f));
		}
	}
