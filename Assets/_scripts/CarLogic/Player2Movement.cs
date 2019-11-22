using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour
{
    SpeedBar speedBar;
    public static float speedText;
	public static string slipText = "";
	
	[Header("Car_Specs")]
    public WheelCollider topLeft;
	public WheelCollider topRight;
	public WheelCollider botLeft;
	public WheelCollider botRight;
    public Transform topRightT;
	public Transform topLeftT;
    public Rigidbody rb;
    public ParticleSystem exhaustEffect;

	[Header("Sound")]
    public AudioClip accelerate;
    public AudioClip collisionSound;
	
	[Header("Movement_Specs")]
    public float speedCount;
	
    private float decelerationSpeed = 30f;
    private float x;
    private float y;
    private float maxSpeed = 30f;
	private float currentRPM;
	private float maxRPM = 3000f;
	private float motorForce = 1000f;
	private float antiRoll = 5000.0f;

	[Header("Ackermann_Specs")]
	public float ackermanLeft;
	public float ackermanRight;
	
	// realistic specs
	private float wheelbase = 2.55f;
	private float reartrack = 1.525f;
	private float turnradius = 11f;
	private float turntime = 8f;
	
	
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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            // play particle effect
            exhaustEffect.Play();
            exhaustEffect.loop = true;

        }

        else
        {
			exhaustEffect.Stop();
            exhaustEffect.loop = false;
        }
    }
	
	private void AntiRoll () 
	{
		WheelHit hit;
		var travelL = 1.0;
		var travelR = 1.0;
		var travelTL = 1.0;
		var travelTR = 1.0;
	 
		var groundedL = botLeft.GetGroundHit(out hit);
		var groundedR = botRight.GetGroundHit(out hit);
		var groundedTL = topRight.GetGroundHit(out hit);
		var groundedTR = topLeft.GetGroundHit(out hit);
		
		if (hit.sidewaysSlip > 0.5 || hit.sidewaysSlip < -0.5)
			slipText = "Drifting!!!";
		else
			slipText = "";
		
		if (groundedL)
			travelL = (-botLeft.transform.InverseTransformPoint(hit.point).y - botLeft.radius) / botLeft.suspensionDistance;
		
		if (groundedR)
			travelR = (-botRight.transform.InverseTransformPoint(hit.point).y - botRight.radius) / botRight.suspensionDistance;

		if (groundedTL)
			travelTL = (-topRight.transform.InverseTransformPoint(hit.point).y - topRight.radius) / topRight.suspensionDistance;

		if (groundedTR)
			travelTR = (-topLeft.transform.InverseTransformPoint(hit.point).y - topLeft.radius) / topLeft.suspensionDistance;
	 
		float antiRollForce = (float)(travelL - travelR) * antiRoll;
		float antiRollForce2 = (float)(travelTL - travelTR) * antiRoll;
		
		//Debug.Log(antiRollForce);
		
		if (groundedL)
			GetComponent<Rigidbody>().AddForceAtPosition(botLeft.transform.up * -antiRollForce,
				   botLeft.transform.position);  
				   
		if (groundedR)
			GetComponent<Rigidbody>().AddForceAtPosition(botRight.transform.up * antiRollForce,
				   botRight.transform.position);  
				   
	    if (groundedTL)
			GetComponent<Rigidbody>().AddForceAtPosition(topLeft.transform.up * -antiRollForce,
				   topLeft.transform.position);  
				   
		if (groundedTR)
			GetComponent<Rigidbody>().AddForceAtPosition(topRight.transform.up * antiRollForce,
				   topRight.transform.position);  
	}
		
    public void Movement()
    {

		//Debug.Log(rb.velocity.magnitude + "p2");
        // use magnitude for length - always positive
        if (rb.velocity.magnitude < maxSpeed)
        {
			if (motorForce < maxRPM) 
			{
				//acceleration
				topLeft.motorTorque = y * motorForce;
				topRight.motorTorque = y * motorForce;
				botLeft.motorTorque = y * motorForce;
				botRight.motorTorque = y * motorForce;
				
				//Debug.Log(rb.velocity.magnitude);
				
				
				
				if (rb.velocity.magnitude > 10)
					motorForce += 1f;
				
				else
					motorForce = 500f;
				
				//motorForce = y * motorForce;
				//Debug.Log(topLeft.motorTorque); // always 300
				//currentRPM += 1 * Time.deltaTime;
				//SoundManager.Instance.PlayOneShot(accelerate);
			}
			
			else 
				ShiftGear();
        }

        else
        {

            // set upper limit for speed
            topLeft.motorTorque = 0;
            topRight.motorTorque = 0;
            botLeft.motorTorque = 0;
            botRight.motorTorque = 0;
			
			
        }
		//Debug.Log(currentRPM);


        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )

        //gui
        //rpmText.text = topLeft.motorTorque.ToString();
        //speedText.text = Mathf.Round(rb.velocity.magnitude * 10) + " KM/H";

        speedText = Mathf.Round(rb.velocity.magnitude * 10);
		
		
    }
	
	private void ShiftGear() 
	{
		
		//Debug.Log(topLeft.motorTorque); // always 300
		
		motorForce = 200;
			
	}
	
	// ackermann steering based on small sedan
    private void Steer()
    {
        /* //steering based on max speed
        var actualSpeed = rb.velocity.magnitude / 50;
        var currentSteer = Mathf.Lerp(10, 1, actualSpeed);
        currentSteer *= x;

        m_steeringAngle = maxSteerAngle * x;

        //front wheel drive
        topLeft.steerAngle = currentSteer;
        topRight.steerAngle = currentSteer; */
		
		if (x > 0) 
		{
			ackermanLeft = Mathf.Rad2Deg * Mathf.Atan(wheelbase/(turnradius + (reartrack/2))) * x;
			ackermanRight = Mathf.Rad2Deg * Mathf.Atan(wheelbase/(turnradius - (reartrack/2))) * x;
			
			topLeft.steerAngle = Mathf.Lerp(ackermanLeft, 0, turntime*Time.deltaTime);
			topRight.steerAngle = Mathf.Lerp(ackermanRight, 0, turntime*Time.deltaTime);
		}
		
		else if (x < 0) 
		{
			ackermanLeft = Mathf.Rad2Deg * Mathf.Atan(wheelbase/(turnradius - (reartrack/2))) * x;
			ackermanRight = Mathf.Rad2Deg * Mathf.Atan(wheelbase/(turnradius + (reartrack/2))) * x;
			
			topLeft.steerAngle = Mathf.Lerp(ackermanLeft, 0, turntime*Time.deltaTime);
			topRight.steerAngle = Mathf.Lerp(ackermanRight, 0, turntime*Time.deltaTime);
		}
		
		else 
		{
			ackermanLeft = 0;
			ackermanRight = 0;
			
			topLeft.steerAngle = Mathf.Lerp(ackermanLeft, 0, turntime*Time.deltaTime);
			topRight.steerAngle = Mathf.Lerp(ackermanRight, 0, turntime*Time.deltaTime);
		}
		
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
        SoundManager.Instance.PlayOneShot(collisionSound);
    }

    private void Update()
    {
        // fill image bar based on speed
        //speedBar.Fill(rb.velocity.magnitude / maxSpeed);

        //Debug.Log(speedBar);

        //Effects();
    }

    // all physics stuff goes here
    private void FixedUpdate()
    {
        GetInput();
        Movement();
        Steer();
        Brake();
        UpdateWheelPoses();
		AntiRoll();

        //Debug.Log();
    }



}
