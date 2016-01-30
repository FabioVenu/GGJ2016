using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    List<int> inventory = new List<int>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        pickIfIngredient(coll.gameObject);        
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        pickIfIngredient(coll.gameObject);        
    }

    void pickIfIngredient(GameObject obj)
    {
        if (obj.tag == "Ingredient")
        {
            inventory.Add(obj.GetComponent<Ingredient>().Type);
            DestroyObject(obj);

            // TODO: update the GUI
        }
    }
}
