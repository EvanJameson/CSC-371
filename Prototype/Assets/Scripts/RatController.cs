using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour 
{
	public float speed = 2, jump_velocity = 5;
	private Transform tf, ground_tf1, ground_tf2;
	private Rigidbody2D rb;
	private float left_trigger;
	private float right_trigger;
	public LayerMask player_mask;

	public bool gt1 = false, gt2 = false;

    public GameObject leftPuff;
    public GameObject rightPuff;

    // Use this for initialization
    void Start () 
	{
		tf = this.transform;
		rb = GetComponent<Rigidbody2D> ();
		ground_tf1 = GameObject.Find (this.name + "/Ground_tag").transform;
		ground_tf2 = GameObject.Find (this.name + "/Ground_tag (1)").transform;
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

        if (oldgt2 == false && gt2 == true && oldgt1 == false)
        {
            //left puff
            GameObject tempL = Instantiate(leftPuff, tf.transform.position, transform.rotation);
            Destroy(tempL, 0.5f);
        }
        if (oldgt1 == false && gt1 == true && oldgt2 == false)
        {
            //right puff
            GameObject tempR = Instantiate(rightPuff, tf.transform.position, transform.rotation);
            Destroy(tempR, 0.5f);
        }
		left_trigger = Input.GetAxis ("Fire3");
		right_trigger = Input.GetAxis ("Fire3");
		Sprint (left_trigger, right_trigger);

		if (Input.GetButtonDown("Jump"))
		{
			Jump ();
		}
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Ladder"))
		{
			Climb ();
		}
	}

	public void Move_H(float horizontal_input)
	{
		//move left and right
		Vector2 move_velocity = rb.velocity;
		move_velocity.x = horizontal_input * speed;
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
		if(gt1 || gt2)
		{
			//vector2.up is a vector of (0,1)
			rb.velocity += jump_velocity * Vector2.up;
		}	
	}

	public void Sprint(float left, float right)
	{
		
		//Sprinting
		if((left > .1f) || (right > .1f) || Input.GetButtonDown("Fire3"))
		{
			speed = 4f;
			jump_velocity = 5f; //should change for other animals\

		}
		else if((left < .1f) || (right < .1f) ||  Input.GetButtonUp("Fire3"))
		{
			speed = 2f;
			jump_velocity = 5f;

		}
	}
}
