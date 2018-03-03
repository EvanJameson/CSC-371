using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catShockwave : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;

		position = new Vector2 (position.x + speed * Time.deltaTime, position.y );

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Debug.Log ("Max x: " + max.x, gameObject);

		if(transform.position.x > 18 ){
			Destroy (gameObject);
		}
	}
}
