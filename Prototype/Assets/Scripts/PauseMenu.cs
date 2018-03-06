using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void exitToMenu()
	{
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		SceneManager.LoadScene("MainMenu");
	}
}
