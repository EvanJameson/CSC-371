using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunnerControl : MonoBehaviour {
	private GameObject boss;
	private GameObject walls;
	private GameObject player;
	private GameObject cam;
	private Rigidbody2D prb;
	private float speed = 10;
	private bool entered = false;
	private bool rotated = false;

	public int phase = 0;

	// Use this for initialization
	void Start () {
		boss = GameObject.Find ("BossGunner");
		walls = GameObject.Find ("Walls");
		cam = GameObject.Find("Main Camera");
		//player = CharacterControl.instance.player;
		//prb = player.GetComponent<Rigidbody2D> ();
		//playerT = player.GetComponent<Transform>();
	}

	void Update()
	{
		Vector3 bottom = new Vector3 (34,4, 0);
		Vector3 top = new Vector3 (34, 20, 0);
		if (entered) {
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, top, 10 * Time.deltaTime);
		}
		if (boss.transform.position.y > 19 && !rotated) {
			boss.transform.Rotate (0, 0, 180);
			rotated = true;

		}
		if (phase == 0) {
			Debug.Log ("phase is 0");
		}
		if (phase == 1) {
			top.y = 40;
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, top, 10 * Time.deltaTime);
			Debug.Log ("phase is 1");
		}
		if (phase == 2) {
			//player.transform.position = Vector3.MoveTowards(player.transform.position, bottom, 20 * Time.deltaTime);
			top.y = 60;
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, top, 10 * Time.deltaTime);
			Debug.Log ("phase is 2");
		}
	}


	void OnTriggerEnter2D (Collider2D other) {
		if (!entered) {
			walls.transform.Translate (new Vector3 (0, -2, 0));
			entered = true;
		}
	}
	public void nextPhase()
	{
		if (phase < 3) {
			walls.GetComponent<SpreadWalls> ().moveWalls ();
			phase += 1;
			//prb.AddForce(new Vector2(0f,100f));
		} else {
			Destroy (gameObject);
		}
			
	}

	public void spanCamera(Vector3 span) //span = new Vector3(location.x, location.y, scale)
	{
		cam.SendMessage("SpanScene", span);
	}
}
