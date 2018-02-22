using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour 
{
	public float speed = 2, jump_velocity = 5;
	public Transform ground_tf1, ground_tf2;
	private Transform tf;
	private Rigidbody2D rb;
	private SpriteRenderer sp;
	public LayerMask player_mask;

	public bool gt1 = false, gt2 = false;

    public GameObject leftPuff;
    public GameObject rightPuff;

    // Use this for initialization
    void Start () 
	{
		sp = GetComponent<SpriteRenderer> ();
		tf = this.transform;
		rb = GetComponent<Rigidbody2D> ();
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

		if(other.gameObject.CompareTag("Rope"))
		{
			Chew (other);
		}

		if (other.gameObject.CompareTag ("Enemy") &&
			Input.GetButtonDown("Fire1")) {

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
		if(gt1 || gt2)
		{
			//vector2.up is a vector of (0,1)
			rb.velocity += CharacterControl.instance.jump_velocity * Vector2.up;
            FindObjectOfType<AudioManager>().Play("Jump");
        }	
	}

	public void Sprint()
	{
		
		//Sprinting
		if(Input.GetButtonDown("Fire3"))
		{
			speed = 4f;

		}
		else if(Input.GetButtonUp("Fire3"))
		{
			speed = 2f;

		}
	}
}
