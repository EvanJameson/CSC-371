using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	string currentLevel;

	public Text start;

	public void Start()
	{
		
		if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
		{
			start.text +=  "\n" + PlayerPrefs.GetString("LevelAccess");
		}
	}

	public void gameStart()
    {
		//this loads the first level on first play
		//or current level based on progress
		currentLevel = PlayerPrefs.GetString("LevelAccess");
        SceneManager.LoadScene(currentLevel);
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
