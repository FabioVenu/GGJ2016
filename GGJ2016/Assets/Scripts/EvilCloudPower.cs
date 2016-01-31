using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EvilCloudPower : MonoBehaviour {

    public GameObject iceTile;
    public GameObject holeTile;

    public GameObject snowText;
    public GameObject holeText;

    public int MaxHole = 1;
    public int MaxIce = 3;

	// Use this for initialization
	void Start () {
        UpdateGUI();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateGUI();
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

    private void UpdateGUI()
    {
        snowText.GetComponent<Text>().text = (MaxIce - Ice.ActiveCount).ToString();
        holeText.GetComponent<Text>().text = (MaxHole - Hole.ActiveCount).ToString();
    }
}
