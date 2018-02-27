using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

	RectTransform rt;
	bool move = false;
	Vector3 slide;


	// Use this for initialization
	void Start () {
		rt = this.gameObject.GetComponent<RectTransform> ();
		slide = new Vector3 (-1.1f,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(move)
		{
			rt.Translate (slide);
			slide.x += slide.x;
			if(slide.x < -600)
			{
				//need to figure out how to stop the slide of the level buttons
				move = false;
				//this.gameObject.SetActive (false);
			}
			if(slide.x < 0 && this.gameObject.transform.position.x == -29.70679)
			{
				//move = false;
			}
		}
	}

	public void Move()
	{
		move = true;
	}
}
