﻿using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerMovement>().Stunned(time);
            coll.gameObject.transform.position = gameObject.transform.position;
        }
    }
}