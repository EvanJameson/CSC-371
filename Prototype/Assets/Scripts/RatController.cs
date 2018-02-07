using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatController : MonoBehaviour 
{
	public float speed = 2, jump_velocity = 5;
	private Transform tf, ground_tf1, ground_tf2;
	private Rigidbody2D rb;

	public Text countText;

	public  int livesCount;


	public LayerMask player_mask;

	public bool gt1 = false, gt2 = false;

    public GameObject leftPuff;
    public GameObject rightPuff;

	//camera shaking
	public float camShakeAmt = 0.1f;
	CameraShake camShake; 
	

    // Use this for initialization
    void Start () 
	{

		livesCount = 5;
		tf = this.transform;
		rb = GetComponent<Rigidbody2D> ();
		ground_tf1 = GameObject.Find (this.name + "/Ground_tag").transform;
		ground_tf2 = GameObject.Find (this.name + "/Ground_tag (1)").transform;
		countText.text = "Count: " + livesCount.ToString ();

		camShake = GameObject.Find ("_GM").GetComponent<CameraShake> ();
		if (camShake == null) {
			Debug.LogError ("No Camerashake script found on object");
		}
	}

	void LateUpdate()
	{
		Sprint ();
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


	void OnTriggerEnter2D(Collider2D other)  
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Enemy"))
		{
			//other.gameObject.SetActive(false);
			if(livesCount > 0){
				livesCount = livesCount - 1;	
				countText.text = "Count: " + livesCount.ToString ();
				camShake.Shake (camShakeAmt, 0.2f);
			}
		}


	}
}
