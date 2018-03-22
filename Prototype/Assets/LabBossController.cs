using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabBossController : MonoBehaviour {

    public bool isRight;
    private int count;

    public GameObject obj1;
    public GameObject obj2;

    public Transform ll1;
    public Transform ll2;
    public Transform ll3;

    public Transform rl1;
    public Transform rl2;
    public Transform rl3;

	// Use this for initialization
	void Start () {
        isRight = false;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        if (count >= 180)
        {
            Instantiate(obj1, rl1);
            count = 0;
        }
        count++;
    }
}
