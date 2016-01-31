using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        checkPlayer(coll.gameObject);
    }

    void checkPlayer(GameObject go)
    {
        if (go.tag == "Player")
        {
            GameManager.Instance.checkIngredients();
        }
    }
}
