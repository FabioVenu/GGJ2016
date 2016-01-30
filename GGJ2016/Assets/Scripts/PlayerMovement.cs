using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb2d;
    public float speed;


	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.MovePosition(rb2d.position + input * speed * Time.deltaTime);
	}
}
