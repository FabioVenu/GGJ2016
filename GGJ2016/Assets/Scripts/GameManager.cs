using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject EvilCloud;

    public static float FixedZ = -5;

    [HideInInspector]
    public static GameManager Instance;

	// Use this for initialization
	void Start () {

        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Will return a new position for the evil cloud, 
    public static Vector3 getRandomEvilCloudPosition()
    {
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        Vector2 newpos = new Vector2(Instance.Player.transform.position.x, Instance.Player.transform.position.y) + direction * Random.Range(0.1f, 10);

        return new Vector3(newpos.x, newpos.y, FixedZ);
    }

}
