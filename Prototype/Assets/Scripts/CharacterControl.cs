using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	public static CharacterControl instance;

	public GameObject player;
	public float jump_velocity = 5f;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

}
