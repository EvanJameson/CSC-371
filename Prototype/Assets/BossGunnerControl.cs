using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunnerControl : MonoBehaviour {
	private GameObject walls;
	private GameObject player;
	private GameObject cam;
	private Rigidbody2D prb;
	private SpriteRenderer sp;
	private float speed = 5f;
	private bool entered = false;
	private bool hit = false;
	private bool dirRight = true;
	private bool initialized = false;
	private float nextShot = 0.0f;
	private float sumCount = 0.0f;
	public int phase = 0;
	public GameObject toxicSyringe;

	// Use this for initialization
	void Awake()
	{
		sp = GetComponent<SpriteRenderer>();
	}
	void Start () {
		//boss = GameObject.Find ("BossGunner");
		walls = GameObject.Find ("Walls");
		cam = GameObject.Find("Main Camera");
		player = CharacterControl.instance.player;
		Debug.Log (player.name);
		prb = player.GetComponent<Rigidbody2D> ();
		//playerT = player.GetComponent<Transform>();
	}
		
	void Update()
	{
		Vector3 bottom = new Vector2 (34f,4f);
		Vector3 target = new Vector2 (32f, 20f);
		if (phase == 0 && !initialized && entered) {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
			sp.flipY = true;
		}	
		if (phase == 1 && hit) {
			target.y += 10f;
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
		else if (phase == 2 && hit) {

			target.y += 20f;
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
		else if (phase == 3 && hit) {
			target.y += 30f;
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
		if (transform.position.y - target.y >= 0.0f) {
			initialized = true;
			hit = false;
			if (dirRight)
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			else
				transform.Translate (-Vector2.right * speed * Time.deltaTime);

			if (transform.position.x >= 37f) {
				dirRight = false;
			}
			
			if (transform.position.x <= 29f) {
				dirRight = true;
			}
		}

		/*Projectile firing*/
		sumCount += 1; 
		nextShot = Random.Range (1, 10) * 60;
		if (initialized && sumCount >= nextShot) {
			sumCount = 0; 
			FindObjectOfType<AudioManager> ().Play ("ShootSound");
			GameObject syringe = (GameObject)Instantiate (toxicSyringe, transform.position, transform.rotation);
			Physics2D.IgnoreCollision (toxicSyringe.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			//nextShot = Random.Range (10, 100);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (!entered) {
			FindObjectOfType<AudioManager> ().Play ("MechDoor");
			FindObjectOfType<AudioManager> ().Play ("ShipTakeoff");

			walls.transform.Translate (new Vector2 (0, -2));
			entered = true;
		}
	}
	public void nextPhase()
	{
		if (phase < 3) {
			walls.GetComponent<SpreadWalls> ().moveWalls ();
			phase += 1;
			hit = true;
			speed += 1f;
			spanCamera(new Vector3(transform.position.x, transform.position.y, 21));
		} else {
			FindObjectOfType<AudioManager> ().Play ("MechDoor");
			//spanCamera(new Vector3(player.transform.position.x, player.transform.position.y, 21));
			walls.transform.Translate (new Vector2 (0, 2));
			Destroy (gameObject);
		}
			
	}

	public void spanCamera(Vector3 span) //span = new Vector3(location.x, location.y, scale)
	{
		cam.SendMessage("SpanScene", span);
	}
}
