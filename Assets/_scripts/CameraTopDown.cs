using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopDown : MonoBehaviour
{

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Camera-TopDown").GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        float charPosX = transform.position.x;
        float charPosZ = transform.position.z;
        float cameraOffset = 100.0f;

        cam.transform.position = new Vector3(charPosX, cameraOffset, charPosZ - 50 );

    }
}
