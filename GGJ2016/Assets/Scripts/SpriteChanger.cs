using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

    public Sprite schemaController;
    public Sprite schemaKeybMouse;
    
    private SpriteRenderer spriteRenderer;


    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = schemaController; // set the sprite to sprite1


        if (ControlliSwitch.IsControllerEnabled)
        {
            spriteRenderer.sprite = schemaKeybMouse;
        }
        else
        {
            spriteRenderer.sprite = schemaController;
        }
    }

}
