using UnityEngine;
using System.Collections;

public class EvilCloudPower : MonoBehaviour {
    public GameObject iceTile;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
            Instantiate(iceTile, position, transform.rotation);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
            Instantiate(iceTile, position, transform.rotation);
        }
	}
}
