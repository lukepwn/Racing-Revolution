using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras = new Camera[1];
    public bool changeAudioListener = true;

    //public Transform target;
    private float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            EnableCamera(cameras[0], true);
        }
        else
        if (Input.GetKey(KeyCode.G))
        {
            EnableCamera(cameras[0], false);

            //topDown();
        }
    }

    private void EnableCamera(Camera cam, bool enabledStatus)
    {
        cam.enabled = enabledStatus;
        //if (changeAudioListener)
            //cam.GetComponent<AudioListener>().enabled = enabledStatus;
    }



    /* void topDown()
    {
        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    } */
}