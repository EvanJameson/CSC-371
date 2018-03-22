using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj1Controller : MonoBehaviour {

    public LabBossController levelController;

    public float speed;
    private float rSpeed;

    private Rigidbody2D rb;
    private Vector2 moveDir;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        levelController = FindObjectOfType<LabBossController>();

		if(levelController.isRight)
        {
            rSpeed = speed;
        }
        else
        {
            rSpeed = -speed;
        }

        moveDir = new Vector2(rSpeed, 0);
        rb.velocity = moveDir;
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.position.x < -20 || rb.position.x > 10)
        {
            Destroy(this.gameObject);
        }
	}

    private void FixedUpdate()
    {
        
    }
}
