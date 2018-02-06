using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

	private DistanceJoint2D dj;
	private HingeJoint2D hj;

	// Use this for initialization
	void Start () {
		dj = this.gameObject.GetComponent<DistanceJoint2D> ();
		hj = this.gameObject.GetComponent<HingeJoint2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1"))
		{
			DistanceJoint2D.Destroy (dj);
			HingeJoint2D.Destroy(hj);
		}
	}
}
