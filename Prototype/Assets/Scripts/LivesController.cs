using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Authors: Tori, Evan
public class LivesController : MonoBehaviour {

	private const float IMMUNITY_TIME = 1.0f;

	private int index; //#lives - 1
	private float timeSinceLastLostLife = 0;

	public GameObject[] lives = new GameObject[5];
	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		
		index = PlayerPrefs.GetInt ("lives") - 1;
		 

		//print ("start lives = " + PlayerPrefs.GetInt("lives"));
		for(int i = 0; i < 5; i++)
		{
			//print (i + " " + index);
			if (i > index)// && index != 4) 
			{
				lives [i].SetActive (false);
			} 
			else 
			{
				lives [i].SetActive (true);
			}
		}
	}

	public void addLife()
	{
		if (index < 4) {
			lives [index + 1].SetActive (true);
			index++;
			PlayerPrefs.SetInt ("lives", index + 1);
		}
	}

	public void removeLife()
	{
		if (PlayerPrefs.GetInt("SuperHaungsMode") == 0) {
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
