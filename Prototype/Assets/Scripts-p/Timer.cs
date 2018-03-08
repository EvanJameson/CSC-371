using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {

	public float timeStart = 0f;
	public Text countup;
	public int isDone = 0;
	GameObject player;
	PlayerControl pc;

	// Use this for initialization
	void Start () {
		//StartCoroutine("GainTime");
		//Time.timeScale = 1;
		countup.fontSize = 100;
		player = GameObject.Find("PlayerGO");
		pc = player.GetComponent<PlayerControl>();

	}
	
	// Update is called once per frame
	void Update () {
		//timeStart+= .005f;
		//countup.text = ("" + timeStart);
		countup.text = ("" + pc.lives);
		if(Input.GetMouseButtonDown(0)){
			Scene loadedLevel = SceneManager.GetActiveScene();
			SceneManager.LoadScene (loadedLevel.buildIndex);
			isDone = 1;
		}
			
	}
	
	/*IEnumerator GainTime()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			if(isDone == 0)
				timeStart++; 
		}
	}*/
}
