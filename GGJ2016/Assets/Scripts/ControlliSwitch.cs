using UnityEngine;
using System.Collections;

public class ControlliSwitch : MonoBehaviour {

    public Sprite spriteController; 
    public Sprite spriteKeybMouse; 
    static public bool IsControllerEnabled = true;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = spriteController; // set the sprite to sprite1
    }

    public void ChangeSprite()
    {
        if (spriteRenderer.sprite == spriteController) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = spriteKeybMouse;
            IsControllerEnabled = false;
        }
        else
        {
            spriteRenderer.sprite = spriteController; // otherwise change it back to sprite1
            IsControllerEnabled = true;
        }
    }
}