using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {

	public GameObject player;
	public Character[] characters;
	public GameObject characterSelectPanel;
	private SpriteRenderer sprite_renderer;
	public GameObject abilityPanel;
	private KeyCode[] charCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
	};
		
	public void OnCharacterSelect(int characterChoice)
	{
		sprite_renderer = player.GetComponent<SpriteRenderer> ();
		characterSelectPanel.SetActive (true);
		abilityPanel.SetActive (true);

		WeaponMarker weaponMarker = player.GetComponentInChildren<WeaponMarker> ();
		AbilityCoolDown[] coolDownButtons = GetComponentsInChildren<AbilityCoolDown> ();
		Character selectedCharacter = characters [characterChoice];
		for (int i = 0; i < coolDownButtons.Length; i++) {
			coolDownButtons [i].Initialize (selectedCharacter.characterAbilities [i], weaponMarker.gameObject);
		}
		sprite_renderer.sprite = selectedCharacter.sprite;


	}
	public void Update()
	{
		for (int i = 0; i < charCodes.Length; i++) {
			if (Input.GetKeyDown (charCodes [i])) {
				int numberPressed = i;
				OnCharacterSelect (numberPressed);
			}
		}
	}

}
