using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author: Braden Saito

public class LabBossController : MonoBehaviour {

    public Text remaining;

    public bool isRight;
    private int count;

    public GameObject levelComplete;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public GameObject wire1;
    public GameObject wire2;

    public Transform rl1;
    public Transform rl2;
    public Transform rl3;

    public int wireCount;

    private int timeDiff;
    private int prevChoice;
	// Use this for initialization
	void Start () {
        isRight = false;
        count = 0;
        prevChoice = 0;
        wireCount = 0;
        remaining.text = "Remaining Wires: 15";
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        if (count == 180)
        {
            float choice;
            if(prevChoice == 3 || prevChoice == 4)
            {
                choice = Random.Range(1, 3);
            }
            else
                choice = Random.Range(1, 4);
            Debug.Log(choice);
            if ((int)choice == 1)
            {
                Instantiate(obj1, rl1);
                Instantiate(wire1, rl1);
            }
            else if ((int)choice == 2)
            {
                Instantiate(obj2, rl2);
                Instantiate(wire2, rl2);
            }
            else if ((int)choice == 3 || (int)choice == 4)
                Instantiate(obj3, rl3);
            prevChoice = (int)choice;
            count = 0;
        }
        count++;
        timeDiff++;
    }

    public void incrementCount()
    {
        if (timeDiff > 20)
        {
            wireCount++;
            timeDiff = 0;
            remaining.text = "Remaining Wires: " + (15 - wireCount);
        }
        if(wireCount >= 15)
        {
			//have to keep it active so timer runs
			levelComplete.GetComponent<Transform> ().position = new Vector3 (-614.1f, -206.6f, 2.25f);
        }
    }
    
    public int getCount()
    {
        return wireCount;
    }
}
