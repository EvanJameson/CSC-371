using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

	private DistanceJoint2D dj;
	private HingeJoint2D hj;
	public bool interact;
	public GameObject player;

	 //for moving platforms

	// Use this for initialization
	void Start () {
		dj = this.gameObject.GetComponent<DistanceJoint2D> ();
		hj = this.gameObject.GetComponent<HingeJoint2D> ();
		player = GameObject.Find ("RatPlayer(Clone)");//.transform;
		//player = GameObject.Find("RatPlayer(Clone)").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Rigidbody2D orb;

			//print ("yeah it broke");
			orb = player.GetComponent<Rigidbody2D>();
			//orb.;
			other.transform.SetParent (transform);

		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			
			other.transform.SetParent (null);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1") && interact)
		{
			DistanceJoint2D.Destroy (dj);
			HingeJoint2D.Destroy(hj);
		}
	}
}
