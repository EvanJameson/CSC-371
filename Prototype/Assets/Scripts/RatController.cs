using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour 
{
	public float speed = 2, jump_velocity = 5;
	private Transform tf, ground_tf1, ground_tf2;
	private Rigidbody2D rb;
	public LayerMask player_mask;

	public bool gt1 = false, gt2 = false;

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
		Sprint ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		

		Move_H (Input.GetAxisRaw("Horizontal"));
		gt1 = Physics2D.Linecast(tf.position, ground_tf1.position, player_mask);
		gt2 = Physics2D.Linecast(tf.position, ground_tf2.position, player_mask);

		if(Input.GetButtonDown("Jump"))
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

	public void Sprint()
	{
		//Sprinting
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed = 4f;
			jump_velocity = 5f; //should change for other animals\

		}
		else if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = 2f;
			jump_velocity = 5f;

		}
	}
}
