using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Ingredient : MonoBehaviour {

    public int      Type = 0;    // 0 to 4

	// Use this for initialization
	void Start () {

        gameObject.transform.DOMoveY(-1, 1).SetRelative(true).SetLoops(-1, LoopType.Yoyo);        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
