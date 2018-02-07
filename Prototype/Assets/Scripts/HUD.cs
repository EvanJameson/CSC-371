using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;

	public Image HeartUi;

	private GameObject player;
	private int idx;
	void Start(){
		player = GameObject.Find ("Player");
	}

	void Update(){
		RatController playerScript = player.GetComponent<RatController> ();
		idx = playerScript.livesCount;
		HeartUi.sprite = HeartSprites [idx];
	}
}