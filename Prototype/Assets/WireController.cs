using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Braden Saito

public class WireController : MonoBehaviour {

    private LabBossController levelController;

    // Use this for initialization
    void Start () {
        levelController = FindObjectOfType<LabBossController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector2(transform.position.x - 0.06f, transform.position.y);
        if(transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1"))
        {
            Destroy(this.gameObject);
            levelController.incrementCount();
            Debug.Log("score");
        }
    }
}
