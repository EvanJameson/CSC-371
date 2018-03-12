using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour 
    {
	public float speed = 4, jump_velocity = 100;
	public Transform ground_tf1, ground_tf2;
	private Transform tf;
	private Rigidbody2D rb;
	private SpriteRenderer sp;
	public LayerMask player_mask;
	public bool immortal;
	private int lives;

    public bool isClingingRight = false;
    public bool isClingingLeft = false;
    public float vel = 0;
    public float velY = 0;
    public float input = 0;
    public int gravity = 1;


	public bool gt1 = false, gt2 = false;
	//private bool moving = false; //for moving platforms

    public GameObject leftPuff;
    public GameObject rightPuff;

    private bool ignore = false;
    private int iCount = 0;

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
        input = Input.GetAxis("Horizontal");
        vel = rb.velocity.x;
        velY = rb.velocity.y;

        // These booleans used for ground puffs 
        bool oldgt1 = gt1;
        bool oldgt2 = gt2;

        if(iCount >= 15)
        {
            ignore = false;
            iCount = 0;
        }

        if (ignore)
        {
            iCount++;
        }
        else
        {
            Move_H(Input.GetAxisRaw("Horizontal"));
            gt1 = Physics2D.Linecast(tf.position, ground_tf1.position, player_mask);
            gt2 = Physics2D.Linecast(tf.position, ground_tf2.position, player_mask);

            if (isClingingLeft && Input.GetKey("space"))
            {
                //left->right cling jump
                isClingingLeft = false;
                rb.gravityScale = gravity;
                rb.velocity = CharacterControl.instance.jump_velocity * Vector2.one;// * high;
                FindObjectOfType<AudioManager>().Play("Jump");
                ignore = true;
                
                isClingingLeft = false;
                isClingingRight = false;
            }
            else if (isClingingRight && Input.GetKey("space"))
            {
                //right->left cling jump
                isClingingRight = false;
                rb.velocity = CharacterControl.instance.jump_velocity * new Vector2(-1, 1);// * high;
                FindObjectOfType<AudioManager>().Play("Jump");
                ignore = true;
                rb.gravityScale = gravity;
                isClingingRight = false;
                isClingingLeft = false;
            }
            else if (Input.GetKey("space"))
            {
                Jump();
            }

        }

        bool hasLanded = false;



        //stuff for wallcling

        //Physics2D.Linecast(tf.position, new Vector2(tf.position.x - 0.5f, tf.position.y), player_mask) &&
        if (input == 1 && vel == 0 && Physics2D.Linecast(tf.position, new Vector2(tf.position.x + 0.5f, tf.position.y), player_mask))
        {
            isClingingRight = true;
        }
        else if(input == -1 && vel == 0 && Physics2D.Linecast(tf.position, new Vector2(tf.position.x - 0.5f, tf.position.y), player_mask))
        {
            isClingingLeft = true;
        }
        else
        {
            isClingingRight = false;
            isClingingLeft = false;
        }

        if(isClingingRight)
        {
            flip();
        }
        if(isClingingLeft)
        {
            flip();
        }

        if((isClingingRight || isClingingLeft) && !Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.gravityScale = 0;
            gt2 = true;
            gt1 = true;
        }
        else
        {
            rb.gravityScale = gravity;
        }


        //end wallcling stuff


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

        
	}


	//CHECK FOR DEATH HERE
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Toxic") && !immortal)
		{
			//died, add a menu, sound or something
			lives--;
			PlayerPrefs.SetInt ("lives", lives);
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

    public void flip()
    {
        Vector3 flipScale = transform.localScale;
        flipScale.x = flipScale.x * -1;
        transform.localScale = flipScale;
    }

	public void Move_H(float horizontal_input)
	{
		//move left and right
		Vector2 move_velocity = rb.velocity;
        Vector3 flipScale = transform.localScale;
		move_velocity.x = horizontal_input * speed;
		if (horizontal_input < 0) {
            //sp.flipX = true;
            if (transform.localScale.x > 0)
            {
                flipScale.x = flipScale.x * -1;
                transform.localScale = flipScale;
            }
		} else if (horizontal_input > 0){
			//sp.flipX = false;
            if(transform.localScale.x < 0)
            {
                flipScale.x = flipScale.x * -1;
                transform.localScale = flipScale;
            }
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

	public void Sprint()
	{
		
		//Sprinting
		if(Input.GetButtonDown("Fire3"))
		{
			speed = 6f;

		}
		else if(Input.GetButtonUp("Fire3"))
		{
			speed = 4f;

		}
	}
}