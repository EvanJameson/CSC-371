using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;

    public GameObject pauseMenu;
	public GameObject levelComplete;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("escape"))
        {
            if(isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
				//exitToMenu();
			}
        }
	}

    public void resumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("Sewer1");
    }

    void pauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<AudioManager>().Pause("Sewer1");
    }

	public void restart(bool death)
    {
		pauseMenu.SetActive (false);
        Time.timeScale = 1;
		Destroy (GameObject.Find("Canvas"));
		//killPlayer ();
		if(death)
		{
			PlayerPrefs.SetInt("lives", 5);
		}
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void exitToMenu()
	{
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		Destroy (GameObject.Find("Canvas"));
		SceneManager.LoadScene("MainMenu");
	}

	void killPlayer()
	{
		Destroy (GameObject.Find("RatPlayer(Clone)"));
		Destroy (GameObject.Find("CatPlayer(Clone)"));
		Destroy (GameObject.Find("MonkeyPlayer(Clone)"));
	}

    public void toggleHaungsMode() {
        CharacterControl.instance.SuperHaungs();
        if (CharacterControl.instance.immortal) {
            GameObject.Find("SuperHaungsText").GetComponent<Text>().text = "Turn Off Super Haungs";
        } else {
            GameObject.Find("SuperHaungsText").GetComponent<Text>().text = "Turn On Super Haungs";
        }
    }
}
