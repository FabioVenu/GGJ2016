﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb2d;
    public float initialSpeed;
    float speed;
    public Vector2 input;

    bool isFixedInput;
    Vector3 fixedInput;

    bool isStunned;
    float startStunnedTime;
    float stunnedTime;

    public AudioClip AudioIceSkid;
    public AudioClip AudioHoleFall;

    private Collider2D collider;

	// Use this for initialization
	void Start () {
        speed = initialSpeed;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        // Check if we are on ice
        int collisions = 0;
        foreach (var ic in Ice.IceColliders)
        {
            if (collider.IsTouching(ic))
            {
                collisions++;
                if (!isFixedInput)
                {
                    fixedInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    if (fixedInput.x==0 && fixedInput.y==0)
                    {
                        isFixedInput = false;
                        break;
                    }

                    speed = 10.0f;
                    isFixedInput = true;

                    GameManager.Instance.AudioSource.PlayOneShot(AudioIceSkid);
                    break;
                }
            }
        }

        if (collisions == 0)
            isFixedInput = false;

        if (isFixedInput)
            input = fixedInput;
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            speed = initialSpeed;
        }
       

        if (isStunned)
        {
            input = Vector2.zero;
            if (Time.time - startStunnedTime > stunnedTime)
            {
                isStunned = false;
            }
        }


        rb2d.MovePosition(rb2d.position + input * speed * Time.deltaTime);
	}

    public void Stunned(float time)
    {
        isStunned = true;
        startStunnedTime = Time.time;
        stunnedTime = time;

        GameManager.Instance.AudioSource.PlayOneShot(AudioHoleFall);
    }

}
