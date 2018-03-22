using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour {

    public float conveyorSpeed;
    public bool rightFace;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("in");
            GameObject player = collision.gameObject;
            if(rightFace)
            {
                Vector2 moveDir = new Vector2(conveyorSpeed, 0);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity + moveDir;
            }
            else
            {
                Vector2 moveDir = new Vector2(-conveyorSpeed, 0);
                player.GetComponent<Rigidbody2D>().AddForce(moveDir);
            }
            
        }
    }
}
