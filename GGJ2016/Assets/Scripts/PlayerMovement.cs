using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb2d;
    public float initialSpeed;
    float speed;
    public Vector2 input;

    bool isFixedInput;
    Vector3 fixedInput;


	// Use this for initialization
	void Start () {
        speed = initialSpeed;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!isFixedInput)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        else input = fixedInput;

        rb2d.MovePosition(rb2d.position + input * speed * Time.deltaTime);
	}

    public void FixInput(float newSpeed)
    {
        isFixedInput = true;
        fixedInput =  new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        speed = newSpeed;
    }
    public void UnfixInput()
    {
        isFixedInput = false;
        speed = initialSpeed;
    }
}
