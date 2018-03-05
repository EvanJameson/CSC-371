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
		//just load new scene with level select
		SceneManager.LoadScene("LevelSelect");
	}

	public void back()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void exit()
	{
		//quit game
		Application.Quit();
	}

	//load the selected level
	public void loadLevel(GameObject button)
	{
		//print (button.name);
		SceneManager.LoadScene (button.name);
	}
}
