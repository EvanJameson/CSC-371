using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour {

	private const float IMMUNITY_TIME = 1.0f;

	private int index; //#lives - 1
	private float timeSinceLastLostLife = 0;

	public GameObject[] lives = new GameObject[5];
	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("lives") == 5) 
		{
			index = PlayerPrefs.GetInt ("lives") - 1;
		}

		for(int i = 0; i < 5; i++)
		{
			if (i > index) 
			{
				lives [index].SetActive (false);
			} 
			else 
			{
				lives [index].SetActive (true);
			}
		}
	}

	public void addLife()
	{
		lives [index].SetActive (true);
		index++;
	}

	public void removeLife()
	{
		Debug.Log(CharacterControl.instance.immortal);
		if (!CharacterControl.instance.immortal) {
			if (index >= 0 && Time.time - timeSinceLastLostLife > IMMUNITY_TIME) {
				lives [index].SetActive (false);
				index--;
				timeSinceLastLostLife = Time.time;
				PlayerPrefs.SetInt ("lives", index + 1);
			}
		}

		if (index >= 0) {
			StartCoroutine(BlinkRed());
		}

		//death handling
		else if(index < 0){
			

			CharacterControl.instance.player.SetActive (false);
			gameOver.SetActive (true);

		}
	}

	public IEnumerator BlinkRed() {
		SpriteRenderer sp = CharacterControl.instance.player.GetComponent<SpriteRenderer>();
        sp.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(255, 255, 255);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
