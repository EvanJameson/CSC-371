using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwooshKill : MonoBehaviour {
	// Use this for initialization
	private string currentLevel;
	private GameObject Boss;
	void Start () {
		/*currentLevel = PlayerPrefs.GetString ("LevelAccess");
		if (currentLevel.Equals ("3 - 4")) {
			Boss = GameObject.Find ("BossGunner");
		}*/
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerStay2D(Collider2D other)
	{


		if(other.gameObject.CompareTag("Rope"))
		{
			other.gameObject.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.SetActive (false);
		}
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals ("BossGunner")) {
			/*if (other.GetComponent<BossGunnerControl> ().phase == 0) {
				other.GetComponent<BossGunnerControl> ().phase = 1;
			}
			if (other.GetComponent<BossGunnerControl> ().phase == 1) {
				other.GetComponent<BossGunnerControl> ().phase = 2;
			}
			if (other.GetComponent<BossGunnerControl> ().phase == 2) {
				other.GetComponent<BossGunnerControl> ().phase = 3;
			}*/
			other.GetComponent<BossGunnerControl> ().nextPhase ();
			Debug.Log (other.GetComponent<BossGunnerControl> ().phase);

		}
	}

}
