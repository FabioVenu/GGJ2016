using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvilCloudPower : MonoBehaviour {
    public GameObject iceTile;
    public GameObject holeTile;

    public int MaxHole = 1;
    public int MaxIce = 3;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && CanThrowIce)
        {
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);

            Instantiate(iceTile, position, new Quaternion(0, 0, 0, 1));
        }

        if (Input.GetButtonDown("Fire2") && CanThrowHole)
        {
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
            Instantiate(holeTile, position, new Quaternion(0, 0, 0, 1));
        }
	}

    public bool CanThrowIce
    {
        get
        {
            return Ice.ActiveCount < MaxIce;
        }
    }

    public bool CanThrowHole
    {
        get
        {
            return Hole.ActiveCount < MaxHole;
        }
    }
}
