using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    List<GameObject> inventory;
	// Use this for initialization
	void Start () {
        inventory = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {      
        if (coll.gameObject.tag == "Pickable")
        {
            GameObject picked = coll.gameObject;
            inventory.Add(coll.gameObject);
            picked.GetComponent<Renderer>().enabled = false;
            picked.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
