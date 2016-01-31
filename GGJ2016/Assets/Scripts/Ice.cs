using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ice : MonoBehaviour {

    public float speed = 8;
    public float Time = 5;

    public AudioClip AudioIce;

    public static int ActiveCount = 0;
    public static List<Collider2D> IceColliders = new List<Collider2D>();

    // Use this for initialization
    void Start () {

        ActiveCount++;
        IceColliders.Add(gameObject.GetComponent<Collider2D>());
        DestroyObject(gameObject, Time);

        GameManager.Instance.AudioSource.PlayOneShot(AudioIce);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnDestroy()
    {
        ActiveCount--;
        IceColliders.Remove(gameObject.GetComponent<Collider2D>());
    }
}
