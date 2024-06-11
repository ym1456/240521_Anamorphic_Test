using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamShift : MonoBehaviour
{
    Camera cam;
    public Transform target;
    public float screenHeight = 1.0f;
    public bool onComputeFov;
    public bool onLensShift;

    public Vector2 lensFix;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float camPosX = this.transform.position.x;
        float camPosY = this.transform.position.y;

        float offsetX = -1 * camPosX + Mathf.Clamp(camPosX,-1,1) * lensFix.x;
        float offsetY = -1 * camPosY + Mathf.Clamp(camPosY, -1, 1) * lensFix.y;

        if (onLensShift)
        {
            cam.lensShift = new Vector2(offsetX, offsetY);
        }

        if (onComputeFov)
        {
            float distance =  target.position.z- cam.transform.position.z;
            float fov = 2.0f * Mathf.Atan(screenHeight / (2.0f * distance)) * Mathf.Rad2Deg;
            cam.fieldOfView = fov;
            Debug.Log(fov);
        }


    }
}
