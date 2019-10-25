using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour
{
    SpeedBar speedBar;

    //public Text rpmText;
    public static float speedText;
    public WheelCollider topLeft, topRight, botLeft, botRight;
    public Transform topRightT, topLeftT;
    public float maxSteerAngle;
    public float motorForce;
    public Rigidbody rb;
    public ParticleSystem exhaustEffect;

    private float speedCount;
    private float decelerationSpeed = 30f;
    private float x;
    private float y;
    private float m_steeringAngle;
    private float maxSpeed = 17;

    void Awake()
    {

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.9f, 0);

        // find other script gameobject to access methods
        //GameObject tempImg = GameObject.Find("SpeedBar1");
        //speedBar = tempImg.GetComponent<SpeedBar>();

    }

   

    public void GetInput()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

    }

    private void Text()
    {
        //Text tempTextBox = Instantiate(speedText, nextPosition, transform.rotation) as Text;
        ////Parent to the panel
        //tempTextBox.transform.SetParent(renderCanvas.transform, false);
        ////Set the text box's text element font size and style:
        //tempTextBox.fontSize = defaultFontSize;
        ////Set the text box's text element to the current textToDisplay:
        //tempTextBox.text = textToDisplay;
    }

    private void Effects()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            // play particle effect
            exhaustEffect.Play();
            exhaustEffect.loop = true;

        }

        else
        {
            exhaustEffect.loop = false;
        }
    }
    public void Movement()
    {

        // use magnitude for length - always positive
        if (rb.velocity.magnitude < maxSpeed)
        {
            //acceleration
            topLeft.motorTorque = y * motorForce;
            topRight.motorTorque = y * motorForce;
            botLeft.motorTorque = y * motorForce;
            botRight.motorTorque = y * motorForce;
        }

        else
        {
            // set upper limit for speed
            topLeft.motorTorque = 0;
            topRight.motorTorque = 0;
            botLeft.motorTorque = 0;
            botRight.motorTorque = 0;
        }


        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )

        //gui
        //rpmText.text = topLeft.motorTorque.ToString();
        //speedText.text = Mathf.Round(rb.velocity.magnitude * 10) + " KM/H";

        speedText = Mathf.Round(rb.velocity.magnitude * 10);

    }

    private void Steer()
    {
        //steering based on max speed
        var actualSpeed = rb.velocity.magnitude / 50;
        var currentSteer = Mathf.Lerp(10, 1, actualSpeed);
        currentSteer *= x;

        m_steeringAngle = maxSteerAngle * x;

        //front wheel drive
        topLeft.steerAngle = currentSteer;
        topRight.steerAngle = currentSteer;
    }

    private void Brake()
    {
        // let go of accel to brake
        if (Input.GetButton("Vertical") == false)
        {
            topLeft.brakeTorque = decelerationSpeed;
            topRight.brakeTorque = decelerationSpeed;
            botLeft.brakeTorque = decelerationSpeed;
            botRight.brakeTorque = decelerationSpeed;
        }

        else
        {
            topLeft.brakeTorque = 0;
            topRight.brakeTorque = 0;
            botLeft.brakeTorque = 0;
            botRight.brakeTorque = 0;
        }


    }

    private void UpdateWheelPoses()
    {
        // wheel transpose
        UpdateWheelPose(topLeft, topLeftT);
        UpdateWheelPose(topRight, topRightT);

    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
        // source coderDaren-unity
    }

    private void OnCollisionEnter(Collision col)
    {
        //print("terrain");
        //topLeft.motorTorque = 0;
        //topRight.motorTorque = 0;
    }

    private void Update()
    {
        // fill image bar based on speed
        //speedBar.Fill(rb.velocity.magnitude / maxSpeed);

        //Debug.Log(speedBar);

        Effects();
    }

    // all physics stuff goes here
    private void FixedUpdate()
    {
        GetInput();
        Movement();
        Steer();
        Brake();
        UpdateWheelPoses();

        //Debug.Log();
    }



}
