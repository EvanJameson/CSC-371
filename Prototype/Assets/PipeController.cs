using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PipeController : MonoBehaviour {

	public GameObject Arrow;
	private Transform tf;
	string progress;
	public string nextLevel;

	int progressIndex;
	int nextIndex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Arrow.SetActive (true);
		}
		if(Input.GetButtonDown("Jump"))
		{

            FindObjectOfType<AudioManager>().Play("PipeWarp");
			progress = PlayerPrefs.GetString ("LevelAccess");
			progressIndex = SceneManager.GetSceneByName (progress).buildIndex;
			nextIndex = SceneManager.GetSceneByName (nextLevel).buildIndex;

			//so if you have progressed further and go backwards it doesnt reset progress
			//pipes tho
			if(progressIndex <= nextIndex)
			{
				PlayerPrefs.SetString ("LevelAccess", nextLevel);
			}
			SceneManager.LoadScene (nextLevel);

           // tf = other.gameObject.GetComponent<Transform> ();
			//tf.position += new Vector3 (2.5f,0,0); 

		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Arrow.SetActive (false);
		}

	}
}
