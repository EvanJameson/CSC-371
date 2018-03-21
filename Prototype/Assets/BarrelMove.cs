using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour {

    public bool rightFace;
    public float maxVel;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rightFace = false;
        maxVel = 5.0f;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rb.velocity.x < 0.01 && rb.velocity.x > -0.01)
        {
            rightFace = !rightFace;
        }

        if(rightFace)
        {
            rb.velocity = (new Vector2(maxVel, rb.velocity.y));
        }
        else
        {
            rb.velocity = (new Vector2(-maxVel, rb.velocity.y));
        }

        if(rb.position.y < -18.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
