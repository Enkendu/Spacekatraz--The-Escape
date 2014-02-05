using UnityEngine;
using System.Collections;

public class SpaceShipMovement : MonoBehaviour {

	// Use this for initialization
	float speed = 1.0f;
	float turnSpeed = 1.0f;
	private float trueSpeed = 0.0f;
	float strafeSpeed = 0.0f;
	float upDownMovement = 0.0f;
	public float shipSpeed = 25.0f;

	//mouse look
	float yRotation;
	float xRotation;
	float ZRotation;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(LevelController.startGame == true)
		{
			yRotation += Input.GetAxis ("Mouse X");
			xRotation += Input.GetAxis ("Mouse Y");
			ZRotation += Input.GetAxis ("Roll");
			transform.rotation = Quaternion.Euler (xRotation, yRotation, ZRotation);
		}

		float roll = Input.GetAxis("Roll");
		float pitch = Input.GetAxis("Pitch");
		float yaw = Input.GetAxis ("Yaw");
		Vector3 strafe = new Vector3(Input.GetAxis("Horizontal")*strafeSpeed*Time.deltaTime, Input.GetAxis("Vertical")*strafeSpeed*Time.deltaTime, 0);

		float power = Input.GetAxis("Power");
		
		//Truespeed controls
		
		if (trueSpeed < 10 && trueSpeed > -3)
		{
			trueSpeed += power;
		}
		if (trueSpeed > 10)
		{
			trueSpeed = 9.99f;	
		}
		if (trueSpeed < -3)
		{
			trueSpeed = -2.99f;	
		}
		if (Input.GetKey("backspace"))
		{
			trueSpeed = 0;
		}


		//rigidbody.AddRelativeTorque(pitch*turnSpeed*Time.deltaTime, yaw*turnSpeed*Time.deltaTime, roll*turnSpeed*Time.deltaTime);
//		rigidbody.AddRelativeForce(0,0,trueSpeed*speed*Time.deltaTime);
//		rigidbody.AddRelativeForce(strafe);

		//rigidbody.AddRelativeForce(0,0,trueSpeed*speed*Time.deltaTime, ForceMode.Impulse);
		//rigidbody.AddRelativeForce(strafe);

		rigidbody.AddRelativeForce(Input.GetAxis("Horizontal")*shipSpeed, Input.GetAxis("Updown")*shipSpeed, Input.GetAxis("Vertical")*shipSpeed);
		//rigidbody.AddRelativeTorque(0 ,0 ,Input.GetAxis("Roll")*shipSpeed);
	}
}

