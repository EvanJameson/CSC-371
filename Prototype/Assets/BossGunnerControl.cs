using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunnerControl : MonoBehaviour {
	private GameObject walls;
	private GameObject player;
	private GameObject cam;
	private Rigidbody2D prb;
	private SpriteRenderer sp;
	private float speed = 5;
	private bool entered = false;
	private bool hit = false;
	private bool dirRight = true;
	private bool initialized = false;
	private float nextShot = 0.0f;
	private float sumDelta = 0f;
	public float fireRate = 10.0f;
	public int phase = 0;
	public Rigidbody2D toxicSyringe;

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
		Vector3 target = new Vector2 (34f, 20f);
		if (phase == 0 && !initialized && entered) {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
			sp.flipY = true;
		}	
		if (phase == 1 && hit) {
			speed += 1;
			target.y += 10f;
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
		else if (phase == 2 && hit) {

			speed += 1;
			target.y += 20f;
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
		else if (phase == 3 && hit) {
			speed += 1;
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
		sumDelta += Time.deltaTime; 
		nextShot = Random.Range (1, 10);
		if (initialized && sumDelta >= nextShot) {
			Debug.Log ("in fire");
			Rigidbody2D syringe = (Rigidbody2D)Instantiate (toxicSyringe, transform.position, transform.rotation); //as Rigidbody2D;
			Physics2D.IgnoreCollision (toxicSyringe.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			sumDelta = 0; 
			nextShot = Random.Range (1, 10);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (!entered) {
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
			spanCamera(new Vector3(transform.position.x, transform.position.y, 21));
		} else {
			Destroy (gameObject);
		}
			
	}

	public void spanCamera(Vector3 span) //span = new Vector3(location.x, location.y, scale)
	{
		cam.SendMessage("SpanScene", span);
	}

	public void moveBoss(Vector3 target)
	{
		transform.position = Vector3.MoveTowards (transform.position, target, 10 * Time.deltaTime);
			//Debug.Log ("phase is 1");
	}
}
