using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public GameObject player;
    public GameObject evilCloud;
    public float fixedZ = -10;
    Camera cam;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPos = player.transform.position;
        Vector2 evilCloudPos = evilCloud.transform.position;

        transform.position = new Vector3((evilCloudPos.x + playerPos.x) / 2,(evilCloudPos.y + playerPos.y) / 2,fixedZ);
        Vector3 playerViewPos = cam.WorldToViewportPoint(playerPos);
        Vector3 evilCloudViewPos = cam.WorldToViewportPoint(evilCloudPos);

        //if (playerViewPos.x > 0.5 || playerViewPos.y > 0.5 || evilCloudViewPos.x > 0.5 || evilCloudViewPos.y > 0.5)
        //{
        //    transform.position += new Vector3 (0,0, - 1);
        //}
	}
}
