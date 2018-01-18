using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed = 2, jump_velocity = 5;
	private Transform tf, ground_tf;
	private Rigidbody2D rb;
	public LayerMask player_mask;

	public bool is_ground = false;

	// Use this for initialization
	void Start () 
	{
		tf = this.transform;
		rb = GetComponent<Rigidbody2D> ();
		ground_tf = GameObject.Find (this.name + "/Ground_tag").transform;
	}

	void LateUpdate()
	{
		Sprint ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		

		Move (Input.GetAxisRaw("Horizontal"));
		is_ground = Physics2D.Linecast(tf.position, ground_tf.position, player_mask);
		if(Input.GetButtonDown("Jump"))
		{
			Jump ();
		}
	}

	public void Move(float horizontal_input)
	{
		//move left and right
		Vector2 move_velocity = rb.velocity;
		move_velocity.x = horizontal_input * speed;
		rb.velocity = move_velocity;
	}

	public void Jump()
	{
		if(is_ground)
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
			jump_velocity = 7f;
		}
		else if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = 2f;
			jump_velocity = 5f;
		}
	}
}
