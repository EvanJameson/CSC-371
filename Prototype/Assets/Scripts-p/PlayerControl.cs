using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public int speed = 10;
	public int playerJumpPower = 10;
	public float knockback = 5;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;
	public bool knockFromUp;
	public int lives = 5;
	PlayerControl player;
	private bool isColliding = false;
	private float moveX;

	public float fireRate = 1.0f;
	public float nextFire;

	Animator anim;
	//private GameObject player;
	void Awake(){
		anim = GameObject.Find ("Canvas").GetComponent<Animator> ();
	}

	void Start(){
	}

	void Update(){
		PlayerMove ();
		isColliding = false;
	}

	void twiceSpeed(){
		speed = speed * 2;
	}
	void PlayerMove(){
		moveX = Input.GetAxis ("Horizontal");

		if(Input.GetButtonDown("Jump") && Time.time > nextFire){
			nextFire = Time.time + fireRate;	
			Jump();

		}

		if(knockbackCount <= 0){
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
		}
		else{
			if(knockFromRight){
				GetComponent<Rigidbody2D> ().velocity = new Vector2(-knockback,knockback);
			}
			if(!knockFromRight){
				GetComponent<Rigidbody2D> ().velocity = new Vector2(knockback,knockback);
			}
			if(knockFromUp){
				GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-knockback);
			}
			knockbackCount -= Time.deltaTime;
		}

	}

	void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);

	}


	void OnTriggerEnter2D(Collider2D col){
		if((col.tag == "AsteroidTag")){
			speed = speed/2;
			Invoke ("twiceSpeed", 1);
			Destroy (col.gameObject);
			if(col.transform.position.y < transform.position.y){ 
				knockFromUp = false;
			}
			else{
				knockFromUp = true;
			}
		}
		else if(col.tag == "EnemyShipTag") {
			if (isColliding)
				return;
			isColliding = true;

			knockbackCount = knockbackLength;
			if(col.transform.position.x < transform.position.x){
				knockFromRight = false;
			}
			else{
				knockFromRight = true;
			}
			if(lives > 0){
				lives = lives - 1;

			}
			else{
				anim.SetTrigger ("GameOver");
				Destroy (gameObject);
			}


		}

		else if(col.tag == "EnemyBulletTag") {
			knockbackCount = knockbackLength;
			if(col.transform.position.x < transform.position.x){
				knockFromRight = false;
			}
			else{
				knockFromRight = true;
			}

				
		}

		else if(col.tag == "bawss"){
			anim.SetTrigger ("GameOver");
			Destroy (gameObject);
			//UnityEditor.EditorApplication.isPlaying = false;
		}
	}







}
