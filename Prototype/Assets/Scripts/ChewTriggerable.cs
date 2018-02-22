using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewTriggerable : MonoBehaviour {
	private Collider2D collider;
	public void Chew()
	{
		if(collider .gameObject.CompareTag("Rope"))
		{
			collider.gameObject.SetActive (false);
		}
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		collider = other;
	}
}
