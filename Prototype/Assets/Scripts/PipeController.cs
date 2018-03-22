using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Authors: Evan Jameson
public class PipeController : MonoBehaviour {

	public GameObject Arrow;
	public GameObject Pipe;
	public GameObject Player;

	private Transform tf;
	private Transform ptf;
	string progress;
	//public string nextLevel;


	int progressIndex;
	int nextIndex;
	// Use this for initialization
	void Start () {
		tf = Pipe.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Player == null)
		{
			Player = GameObject.Find ("RatPlayer(Clone)");
			ptf = Player.GetComponent<Transform>();
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Arrow.SetActive (true);
		}
		if(Input.GetButtonDown("Jump"))
		{
            FindObjectOfType<AudioManager>().Play("PipeWarp");

			//sends player to the specified pipe
			ptf.position = tf.position;
			//print ("sopolo");
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Arrow.SetActive (false);
		}

	}
}
