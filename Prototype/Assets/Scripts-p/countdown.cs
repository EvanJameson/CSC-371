using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {
	Animator anim;
	public float myCoolTimer = 10f;
	public Text timerText;
	GameObject player;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}

	void Awake(){
		anim = GameObject.Find ("Canvas").GetComponent<Animator> ();
		player = GameObject.Find ("PlayerGO");

	}
	
	// Update is called once per frame
	void Update () {
		
		if(myCoolTimer < 0){
			anim.SetTrigger ("GameOver");
			Destroy (player);
		}
		else{
			myCoolTimer -= Time.deltaTime;
			timerText.text = myCoolTimer.ToString ("f0");
		}
	}
}
