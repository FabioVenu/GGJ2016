using UnityEngine;
using System.Collections;

public class EvilCloudMovement : MonoBehaviour {

    Vector3 speed = Vector3.zero;
    public float fixedZ = 2;
    float smoothTime = 1;
    Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, fixedZ);
        transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref speed, smoothTime);
           
        //rb2d.MovePosition(rb2d.position + )
        
	}
}
