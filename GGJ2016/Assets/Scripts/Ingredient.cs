using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Ingredient : MonoBehaviour {

    public int          Type = 0;    // 0 to 4
    public GameObject   PickedPS;    // the picked particle system

    public AudioClip AudioPickup;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {

        sprite = gameObject.GetComponent<SpriteRenderer>();

        // looping animation
        gameObject.transform.DOMoveY(-1, 1).SetRelative(true).SetLoops(-1, LoopType.Yoyo);        
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    private bool taken = false;
    public bool CanBeTaken
    {
        get
        {
            return !taken;
        }
    }

    // The taken animation!
    public void Taken()
    {
        taken = true;

        // particle boom
        if (PickedPS != null)
        {
            GameObject ps = Instantiate(PickedPS, gameObject.transform.position, new Quaternion(0, 0, 0, 1)) as GameObject;
            ps.GetComponent<ParticleSystem>().Play();
            DestroyObject(ps, 7f);
        }

        //  fade
        sprite.material.DOFade(0.0f, 2.0f).OnComplete(() => DestroyObject(gameObject));

        GameManager.Instance.AudioSource.PlayOneShot(AudioPickup);
    }
}
