using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STarGenerator : MonoBehaviour {

	public GameObject StarGO;
	public int MaxStars;
	
	
	// Use this for initialization
	void Start () {
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));
		
		for(int i = 0; i < MaxStars; ++i){
			GameObject star = (GameObject)Instantiate(StarGO);
			
			star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
			
			star.GetComponent<Star> ().speed = -(1f * Random.value + 1.5f);
			
			star.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
