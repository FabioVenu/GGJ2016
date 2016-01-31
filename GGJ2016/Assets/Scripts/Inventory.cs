using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    List<int> inventory = new List<int>();

    public Dictionary<GameObject, GameObject> dict = new Dictionary<GameObject, GameObject>();

	// Use this for initialization
	void Start () {
                
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        pickIfIngredient(coll.gameObject);
        useIfPowerUp(coll.gameObject);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        pickIfIngredient(coll.gameObject);
        useIfPowerUp(coll.gameObject);
    }

    void pickIfIngredient(GameObject obj)
    {
        if (obj.tag == "Ingredient")
        {
            var ingredient = obj.GetComponent<Ingredient>();

            if (ingredient.CanBeTaken)
            {
                ingredient.Taken();
                inventory.Add(ingredient.Type);
            }
            

            // TODO: update the GUI
        }
    }

    void useIfPowerUp(GameObject obj)
    {
        if (obj.tag == "PowerUp")
        {
            var powerup = obj.GetComponent<PowerUp>();

            if (powerup.CanBeTaken)
            {
                powerup.Taken();
            }


            // TODO: update the GUI
        }
    }

    public List<int> getInventory()
    {
        return inventory;
    }
}
