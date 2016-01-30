using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {
    public float speed = 8;
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
            coll.gameObject.GetComponent<PlayerMovement>().FixInput(speed);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerMovement>().UnfixInput();
        }
    }
}
