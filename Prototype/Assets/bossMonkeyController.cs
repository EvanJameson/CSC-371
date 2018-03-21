using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMonkeyController : MonoBehaviour {

    public GameObject barrel;
    public Transform launch1;
    public Transform launch2;
    public Transform launch3;

    private int count;

	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
		if(count == 0)
        {
            //throw barrels
            GameObject throw1 = (GameObject)Instantiate(barrel, launch1);
            throw1.GetComponent<Rigidbody2D>().velocity = new Vector2(throw1.GetComponent<Rigidbody2D>().velocity.x, 5.0f);
        }
        if(count == 10)
        {
            GameObject throw2 = (GameObject)Instantiate(barrel, launch2);
            throw2.GetComponent<Rigidbody2D>().velocity = new Vector2(throw2.GetComponent<Rigidbody2D>().velocity.x, 10.0f);
        }

        if (count == 20)
        {
            GameObject throw3 = (GameObject)Instantiate(barrel, launch3);
            throw3.GetComponent<Rigidbody2D>().velocity = new Vector2(throw3.GetComponent<Rigidbody2D>().velocity.x, 17.0f);
        }

        if (count > 300)
        {
            count = 0;
        }
        else
        {
            count++;
        }
    }
}
