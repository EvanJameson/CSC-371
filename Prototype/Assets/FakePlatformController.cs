using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformController : MonoBehaviour {
	private int sum = 0;
	private bool touching = false,falling = false;
	private Rigidbody2D rb;
	private BoxCollider2D bc;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		bc = GetComponent <BoxCollider2D> ();
	}
	
	// Update is called once per frame
	//platform will break, if youre not on it the time rests not instantly but slowly
	void Update () {
		if (touching) 
		{
			sum += 1;
			if(sum == 120)
			{
				falling = true;
				rb.isKinematic = false;
			}
		} 
		else 
		{
			if(sum > 0)
			{
				sum -= 1;
			}
		}

		if (sum == 480) 
		{
			gameObject.SetActive (false);
		}

		if(falling)
		{
			sum += 1;
		}
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			touching = true;
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Tile"))
		{
			//gameObject.SetActive (false);
		}
	}
}
