using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Authors: Tori, Nick Sciacqua
public class CharacterSelector : MonoBehaviour {

	public Character[] characters;
	public GameObject abilityPanel;
	public GameObject characterPanel;

	private KeyCode[] charCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
	};

    private int curChar = 0;

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
            Vector2 velocity = CharacterControl.instance.player.GetComponent<Rigidbody2D>().velocity;
            Destroy(CharacterControl.instance.player);

            if (characterChoice == 1)
            {
                Transform tmp = t;
                tmp.transform.position = new Vector2(tmp.transform.position.x, tmp.transform.position.y);
                curChar = 1;
                CharacterControl.instance.player = Instantiate(selectedCharacter.prefab, tmp.transform.position, t.transform.rotation);
            }
            else if(characterChoice == 0 && curChar == 1)
            {
                Transform tmp = t;
                tmp.transform.position = new Vector2(tmp.transform.position.x, tmp.transform.position.y);
                curChar = 0;
                CharacterControl.instance.player = Instantiate(selectedCharacter.prefab, tmp.transform.position, t.transform.rotation);
            }
            else
            { 
                CharacterControl.instance.player = Instantiate(selectedCharacter.prefab, t.transform.position, t.transform.rotation);
                curChar = characterChoice;
            }
            CharacterControl.instance.player.GetComponent<Rigidbody2D>().velocity = velocity;
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

        bool mouseNext = Input.GetKeyDown("1") || Input.GetKeyDown("z") || Input.GetKeyDown("j");
        bool catNext = Input.GetKeyDown("2") || Input.GetKeyDown("x") || Input.GetKeyDown("k");
        bool monkeyNext = Input.GetKeyDown("3") || Input.GetKeyDown("c") || Input.GetKeyDown("l");

        if(mouseNext && curChar != 0)
        {
            OnCharacterSelect(0);
        }
        else if(catNext && curChar != 1 && PlayerPrefs.GetInt("hasCat") == 1)
        {
            OnCharacterSelect(1);
        }
        else if(catNext && curChar != 1 && PlayerPrefs.GetInt("hasCat") == 0)
        {
            Debug.Log("cat not available");
        }
        if(monkeyNext && curChar != 2 && PlayerPrefs.GetInt("hasMonkey") == 1)
        {
            OnCharacterSelect(2);
        }
        else if (catNext && curChar != 2 && PlayerPrefs.GetInt("hasMonkey") == 0)
        {
            Debug.Log("monkey not available");
        }

        /*		for (int i = 0; i < charCodes.Length; i++) {     old code, doensn't really work for the remapping
                    if (Input.GetKeyDown (charCodes [i])) {
                        int numberPressed = i;
                        if (numberPressed == 0 && curChar != 0) {
                            OnCharacterSelect (numberPressed);
                        } else if (numberPressed == 1 && PlayerPrefs.GetInt ("hasCat") == 1 && curChar != 1) {
                            OnCharacterSelect (1);
                        } else if (numberPressed == 1 && PlayerPrefs.GetInt ("hasCat") == 0) {
                            Debug.Log ("cat not available");
                        } else if (numberPressed == 2 && PlayerPrefs.GetInt ("hasMonkey") == 1 && curChar != 2) {
                            OnCharacterSelect (2);
                        } else if (numberPressed == 2 && PlayerPrefs.GetInt ("hasMonkey") == 0) {
                            Debug.Log ("Monkey not available");
                        }
                    }

                }*/
    }

}
