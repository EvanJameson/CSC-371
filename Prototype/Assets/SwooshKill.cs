using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwooshKill : MonoBehaviour {

	// Use this for initialization
	void Start () {

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

}
