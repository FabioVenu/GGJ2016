using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public GameObject player;
    public GameObject evilCloud;
    public float fixedZ = -10;
    public float CameraCenterAverage = 0.2f; // more centered towards Player
    public float CameraMinZoomOutSize = 6;        
    public float CameraMaxZoomOutSize = 22;       
    public float CameraZoomInTime = 1;
    public float CameraZoomOutTime = 0.5f;
    Camera cam;

    private float CameraZoomCurrentVelocity = 0.0f;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPos = player.transform.position;
        Vector2 evilCloudPos = evilCloud.transform.position;

        var wp1 = cam.WorldToViewportPoint(playerPos);
        var wp2 = cam.WorldToViewportPoint(evilCloudPos);

        bool playerVisible = (wp1.x >= 0 && wp1.x <= 1) && (wp1.y >= 0 && wp1.y <= 1);
        bool evilCloudVisible = (wp2.x >= 0 && wp2.x <= 1) && (wp2.y >= 0 && wp2.y <= 1);

        float cameraSize = CameraMinZoomOutSize;
        float cameraZoomSpeed = 0;
        if (!playerVisible || !evilCloudVisible)
        {
            cameraSize = CameraMaxZoomOutSize;
            cameraZoomSpeed = CameraZoomOutTime;
        }
        else
        {
            cameraSize = CameraMinZoomOutSize;
            cameraZoomSpeed = CameraZoomInTime;
        }

        Vector2 camerapos = Vector2.Lerp(new Vector2(playerPos.x, playerPos.y), new Vector2(evilCloudPos.x, evilCloudPos.y), CameraCenterAverage);

        transform.position = new Vector3(camerapos.x, camerapos.y, fixedZ);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSize, ref CameraZoomCurrentVelocity, cameraZoomSpeed);
            
    }
}
