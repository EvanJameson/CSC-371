using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingController : MonoBehaviour
{
    private GameObject hanging;
    // Use this for initialization
    void Start()
    {
        hanging = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("Fire1") && other.gameObject.CompareTag("Player"))//other.gameObject.CompareTag("Rope") && Input.GetButtonDown("Fire1"))
        {
            hanging.gameObject.SetActive(false);
            //this.gameObject.SetActive (false);

        }
    }
}