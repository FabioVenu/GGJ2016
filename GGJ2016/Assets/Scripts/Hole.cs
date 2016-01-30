using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    public float PlayerStunTime;
    public float Time;

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
            coll.gameObject.GetComponent<PlayerMovement>().Stunned(PlayerStunTime);
            coll.gameObject.transform.position = gameObject.transform.position;
        }
    }

    void OnDestroy()
    {
        ActiveCount--;
    }
}
