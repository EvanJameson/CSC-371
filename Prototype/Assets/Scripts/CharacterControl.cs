using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {

	public const int RAT = 0;
	public const int CAT = 1;
    public const int MONKEY = 2;

	public static CharacterControl instance;

	public GameObject player;
	public float jump_velocity;
	public int characterNumber;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		this.characterNumber = -1;
	}

	public bool isRat() {
		return characterNumber == RAT;
	}

	public bool isCat() {
		return characterNumber == CAT;
	}

    public bool isMonkey()
    {
        return characterNumber == MONKEY;
    }

}
