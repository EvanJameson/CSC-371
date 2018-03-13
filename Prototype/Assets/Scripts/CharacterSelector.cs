﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {

	public Character[] characters;
	public GameObject abilityPanel;
	public GameObject characterPanel;

	private KeyCode[] charCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
	};

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start() {
		OnCharacterSelect (0);
		DontDestroyOnLoad (transform.gameObject);
	}
		
	public void OnCharacterSelect(int characterChoice)
	{
		abilityPanel.SetActive (true);

		Character selectedCharacter = characters [characterChoice];

		/* Destroy current character and instantiate new character */
		if (CharacterControl.instance != null && CharacterControl.instance.player != null) {
			Transform t = CharacterControl.instance.player.transform;
			Destroy (CharacterControl.instance.player);
			CharacterControl.instance.player = Instantiate (selectedCharacter.prefab, t.transform.position, t.transform.rotation);
		} else {
			CharacterControl.instance.player = Instantiate (selectedCharacter.prefab);
		}

		CharacterControl.instance.jump_velocity = selectedCharacter.jump_velocity;
		CharacterControl.instance.characterNumber = characterChoice;

		FindObjectOfType<AudioManager>().Play("Transform");
        if (characterPanel != null) {
        	characterPanel.SendMessage("SwapCharacter", characterChoice);
        }

		WeaponMarker weaponMarker = CharacterControl.instance.player.GetComponentInChildren<WeaponMarker> ();
		AbilityCoolDown[] coolDownButtons = GetComponentsInChildren<AbilityCoolDown> ();

		for (int i = 0; i < coolDownButtons.Length; i++) {
			coolDownButtons [i].Initialize (selectedCharacter.characterAbilities [i], weaponMarker.gameObject);
		}

    }
	public void Update()
	{
		
		for (int i = 0; i < charCodes.Length; i++) {
			if (Input.GetKeyDown (charCodes [i])) {
				int numberPressed = i;
				if (numberPressed == 0) {
					OnCharacterSelect (numberPressed);
				} else if (numberPressed == 1 && PlayerPrefs.GetInt ("hasCat") == 1) {
					OnCharacterSelect (1);
				} else if (numberPressed == 1 && PlayerPrefs.GetInt ("hasCat") == 0) {
					Debug.Log ("cat not available");
				} else if (numberPressed == 2 && PlayerPrefs.GetInt ("hasMonkey") == 1) {
					OnCharacterSelect (2);
				} else if (numberPressed == 2 && PlayerPrefs.GetInt ("hasMonkey") == 0) {
					Debug.Log ("Monkey not available");
				}
			}

		}
	}

}
