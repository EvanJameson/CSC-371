using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void gameStart()
    {
		//Maybe change this to previously loaded level?
        SceneManager.LoadScene("Level1");
    }

	public void levelSelect()
	{
		//figure out how to store these inbetween game launches yo

	}

	public void exit()
	{
		//quit game
		Application.Quit();
	}
}
