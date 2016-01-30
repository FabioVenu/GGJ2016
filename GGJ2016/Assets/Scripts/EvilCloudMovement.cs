using UnityEngine;
using System.Collections;

public class EvilCloudMovement : MonoBehaviour {

    Vector3 vectorSpeed = Vector3.zero;
    public bool     joystickInserted = true;
    public float    speed = 5;    
    float           smoothTime = 1;
    Rigidbody2D     rb2d;
    SpriteRenderer spriterenderer;

    public float    LifeTime = 5;

    private float   StartTime=-1, EndTime=-1;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
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

        var t = Time.time;

        if (IsTimeEnded)
            Respawn();
        
        // Transparency dependent on LifeTime
        spriterenderer.color = new Color(spriterenderer.color.r, spriterenderer.color.g, spriterenderer.color.b, 1.0f - TimePercentage);
    }

    void MouseController()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, GameManager.FixedZ);
        transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref vectorSpeed, smoothTime);
    }

    void JoystickController()
    {
        try
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("HorizontalCloud"), Input.GetAxisRaw("VerticalCloud"));
            rb2d.MovePosition(rb2d.position + input * speed * Time.deltaTime);
        }
        catch
        {}
    }

    // will return true if our time has finished
    public bool IsTimeEnded
    {
        get
        {
            return StartTime==-1 || Time.time >= EndTime;
        }
    }

    public float TimePercentage
    {
        get
        {
            return (Time.time - StartTime) / (EndTime - StartTime);
        }
    }

    // Will give a new position/time to the evil cloud
    public void Respawn()
    {
        StartTime = Time.time;
        EndTime = Time.time + LifeTime;

        //TODO: get new position from manager
        transform.localPosition = GameManager.getRandomEvilCloudPosition();




    }
}
