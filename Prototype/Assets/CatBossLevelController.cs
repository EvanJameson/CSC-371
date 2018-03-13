using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBossLevelController : MonoBehaviour {

    public GameObject hanging1;
    public GameObject hanging2;
    public GameObject hanging3;
    public GameObject hanging4;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject boss;
    public GameObject pipe;
	public GameObject trigger; //levelcomplete trigger

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hanging1.activeInHierarchy)
        {
            if(!box1.activeInHierarchy)
            {
                hanging3.SetActive(true);
            }
        }
        if(hanging3.activeInHierarchy)
        {
            if (!box3.activeInHierarchy)
            {
                hanging2.SetActive(true);
            }
        }
        if (hanging2.activeInHierarchy)
        {
            if (!box2.activeInHierarchy)
            {
                hanging4.SetActive(true);
            }
        }
        if (hanging4.activeInHierarchy)
        {
            if (!box4.activeInHierarchy)
            {
                pipe.SetActive(true);
				trigger.SetActive (true);
				//trigger.GetComponent<Transform> ().position = pipe.GetComponent<Transform>().position;
                boss.SetActive(false);
            }
        }
    }
}
