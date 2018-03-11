using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour 
{
	public float speed = 4, jump_velocity = 100;
	public Transform ground_tf1, ground_tf2;
	private Transform tf;
	private Rigidbody2D rb;
	private SpriteRenderer sp;
	public LayerMask player_mask;
	public bool immortal;
	private int lives;

	private LivesController lc;

	public bool gt1 = false, gt2 = false;
	//private bool moving = false; //for moving platforms

    public GameObject leftPuff;
    public GameObject rightPuff;

	private SpriteRenderer mySpriteRenderer;
	public GameObject PlayerSwoosh; // players' bite swoosh 
	public GameObject SwooshPosition01;
	public GameObject SwooshPosition02;

    // Use this for initialization
    void Start () 
	{
		sp = GetComponent<SpriteRenderer> ();
		tf = this.transform;
		rb = GetComponent<Rigidbody2D> ();
		lives = PlayerPrefs.GetInt("lives");
	}

	void LateUpdate()
	{
		//Sprint ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
        // These booleans used for ground puffs 
        bool oldgt1 = gt1;
        bool oldgt2 = gt2;

        Move_H (Input.GetAxisRaw("Horizontal"));
		gt1 = Physics2D.Linecast(tf.position, ground_tf1.position, player_mask);
		gt2 = Physics2D.Linecast(tf.position, ground_tf2.position, player_mask);

        bool hasLanded = false;

        if (oldgt2 == false && gt2 == true && oldgt1 == false)
        {
            //left puff
            GameObject tempL = Instantiate(leftPuff, tf.transform.position, transform.rotation);
            Destroy(tempL, 0.5f);

            FindObjectOfType<AudioManager>().Play("LandingSound");
            hasLanded = true;
        }
        if (oldgt1 == false && gt1 == true && oldgt2 == false)
        {
            //right puff
            GameObject tempR = Instantiate(rightPuff, tf.transform.position, transform.rotation);
            Destroy(tempR, 0.5f);
            if(!hasLanded)
            {
                FindObjectOfType<AudioManager>().Play("LandingSound");
            }
        }


		Sprint ();

		if (Input.GetKey("space"))
		{
			Jump ();
		}
	}

	void Awake(){
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.X)){
			//instantiate swoosh
			StartCoroutine(HandleSwoosh());

		}
	}



	private IEnumerator HandleSwoosh(){
		GameObject swoosh = (GameObject)Instantiate(PlayerSwoosh);
		if(mySpriteRenderer != null){
			if(mySpriteRenderer.flipX == true){
				swoosh.transform.position = SwooshPosition02.transform.position;
				swoosh.GetComponent<SpriteRenderer> ().flipX = true;
			}
			else{
				swoosh.transform.position = SwooshPosition01.transform.position;
			}
		}

		swoosh.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity; 
		yield return new WaitForSeconds (0.2f);
		GameObject.Destroy (swoosh);

	}

	//CHECK FOR DEATH HERE
	//bug, touching toxic triggers this twice
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Toxic") && !immortal)
		{
			//died, add a menu, sound or something
			lives--;
			PlayerPrefs.SetInt ("lives", lives);
			lc = GameObject.Find ("Lives").GetComponent<LivesController> ();
			lc.removeLife ();

			if(lives == 0)
			{
				//add menu that asks to retry or exit to main menu
				gameObject.SetActive (false);
			}

		}
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Ladder"))
		{
			Climb ();
		}

		if(other.gameObject.CompareTag("Rope"))
		{
			Chew (other);
		}

		if (other.gameObject.CompareTag ("Enemy") &&
			Input.GetButtonDown("Fire1")) {
		}

		if(other.gameObject.CompareTag("Box"))
		{
			/*Vector2 move_velocity = rb.velocity;
			Rigidbody2D orb = GetComponent<Rigidbody2D> ();
			Vector2 box_velocity = orb.velocity;
			move_velocity.x += box_velocity.x;// * speed;
			rb.velocity = move_velocity;*/
			Transform otf = GetComponent<Transform> ();
			transform.position = otf.position;
			print ("yeah");
		}
	}

	public void Chew(Collider2D other)
	{
		if(Input.GetButtonDown("Fire1"))
		{
			
			other.gameObject.SetActive (false);
		}
	}

	public void Move_H(float horizontal_input)
	{
		//move left and right
		Vector2 move_velocity = rb.velocity;
		move_velocity.x = horizontal_input * speed;
		if (horizontal_input < 0) {
			sp.flipX = true;
		} else if (horizontal_input > 0){
			sp.flipX = false;
		}
		rb.velocity = move_velocity;
	}

	public void Move_V(float vertical_input)
	{
		//move left and right
		Vector2 move_velocity = rb.velocity;
		move_velocity.y = vertical_input * speed;
		rb.velocity = move_velocity;
	}

	public void Climb()
	{
		Move_V (Input.GetAxisRaw("Vertical"));

	}

	public void Jump()
	{
		Vector2 high = new Vector2 (0f,2.3f);
		if(gt1 || gt2)
		{
			//vector2.up is a vector of (0,1)
			rb.velocity += CharacterControl.instance.jump_velocity * Vector2.up;// * high;
            FindObjectOfType<AudioManager>().Play("Jump");
        }	
	}

	//make rat run faster, dash for cat is here
	public void Sprint()
	{
		
		//Sprinting for rat
		if(this.name == "RatPlayer(Clone)")
		{
			if(Input.GetButtonDown("Fire3"))
			{
				speed = 6f;

			}
			else if(Input.GetButtonUp("Fire3"))
			{
				speed = 4f;

			}
		}
		if(this.name == "CatPlayer(Clone)")
		{
			//check what direction the player is facing
			if (sp.flipX == false) //facing right
			{
				rb.AddForce (transform.forward * 10);
			} 
			else if (sp.flipX) //facing left
			{
				rb.AddForce (transform.forward * 10);
			}
		}
	}
}
