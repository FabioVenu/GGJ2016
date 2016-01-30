using UnityEngine;
using System.Collections;

public class EvilCloudMovement : MonoBehaviour {

    Vector3 vectorSpeed = Vector3.zero;
    public bool joystickInserted = true;
    public float speed = 5;
    public float fixedZ = 2;
    float smoothTime = 1;
    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (joystickInserted)
        {
            JoystickController();
        }
        else
        {
            MouseController();
        }
        
        //rb2d.MovePosition(rb2d.position + )
        
       
	}

    void MouseController()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, fixedZ);
        transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref vectorSpeed, smoothTime);
    }

    void JoystickController()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("HorizontalCloud"), Input.GetAxisRaw("VerticalCloud"));
        rb2d.MovePosition(rb2d.position + input * speed * Time.deltaTime);
    }
}
