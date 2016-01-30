using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Ingredient : MonoBehaviour {

    public int      Type = 0;    // 0 to 4

	// Use this for initialization
	void Start () {

        var pos = gameObject.transform.position;
        gameObject.transform.DOMoveY(pos.y-1, 1).SetLoops(-1, LoopType.Yoyo);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
