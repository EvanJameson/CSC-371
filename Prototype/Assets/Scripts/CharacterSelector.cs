using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {

	public Character[] characters;
	public GameObject characterSelectPanel;
	public GameObject abilityPanel;
	private KeyCode[] charCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
	};
		
	public void OnCharacterSelect(int characterChoice)
	{
		characterSelectPanel.SetActive (false);
		abilityPanel.SetActive (true);

		WeaponMarker weaponMarker = CharacterControl.instance.player.GetComponentInChildren<WeaponMarker> ();
		AbilityCoolDown[] coolDownButtons = GetComponentsInChildren<AbilityCoolDown> ();
		Character selectedCharacter = characters [characterChoice];
		for (int i = 0; i < coolDownButtons.Length; i++) {
			coolDownButtons [i].Initialize (selectedCharacter.characterAbilities [i], weaponMarker.gameObject);
		}

		/* Destroy current character and instantiate new character */
		Transform t = CharacterControl.instance.player.transform;
		Destroy (CharacterControl.instance.player);
		CharacterControl.instance.player = Instantiate(selectedCharacter.prefab, t.transform.position, t.transform.rotation);
		CharacterControl.instance.jump_velocity = selectedCharacter.jump_velocity;

        FindObjectOfType<AudioManager>().Play("Transform");

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
