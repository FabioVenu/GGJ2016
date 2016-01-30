using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

    public float speed = 8;
    public float Time = 5;

    public static int ActiveCount = 0;

    // Use this for initialization
    void Start () {

        ActiveCount++;
        DestroyObject(gameObject, Time);
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
    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("STAY");
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


    void OnDestroy()
    {
        GameManager.Instance.Player.GetComponent<PlayerMovement>().UnfixInput();
        ActiveCount--;
    }
}
