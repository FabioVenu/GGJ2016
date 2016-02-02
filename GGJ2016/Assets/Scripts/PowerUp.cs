using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PowerUp : MonoBehaviour {

    public int          Type = 0;    // type of powerup 
    public GameObject   PickedPS;    // the picked particle system

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {

        sprite = gameObject.GetComponent<SpriteRenderer>();

        //gameObject.transform.position = spawnPoint.transform.position + new Vector3(Random.Range(0, range), Random.Range(0, range), 0);

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

        // Add Power
        switch (Type)
        {
            case 0:
                // Time +
                Timer.Instance.AddTime(10);
                break;

            case 1:
                CameraManager.Instance.ActivatePowerUpZoom();
                break;
        }
       
    }


   
}
