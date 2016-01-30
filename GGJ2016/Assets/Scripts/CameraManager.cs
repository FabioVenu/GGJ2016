using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public GameObject player;
    public GameObject evilCloud;
    public float fixedZ = -10;
    public float CameraCenterAverage = 0.5f; // centrato tra i due punti
    public float CameraMinZoomOutSize = 6;        
    public float CameraMaxZoomOutSize = 10;       
    public float CameraZoomSpeed = 1;           
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
        if (!playerVisible || !evilCloudVisible)
            cameraSize = CameraMaxZoomOutSize;
        else
            cameraSize = CameraMinZoomOutSize;

        Vector2 camerapos = Vector2.Lerp(new Vector2(playerPos.x, playerPos.y), new Vector2(evilCloudPos.x, evilCloudPos.y), CameraCenterAverage);

        transform.position = new Vector3(camerapos.x, camerapos.y, fixedZ);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSize, ref CameraZoomCurrentVelocity, CameraZoomSpeed);
            
    }
}
