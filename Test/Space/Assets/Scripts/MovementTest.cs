using UnityEngine;
using System.Collections;

public class MovementTest : MonoBehaviour {

	// Use this for initialization
	float speed = 1.0f;
	float turnSpeed = 1.0f;
	private float trueSpeed = 0.0f;
	float strafeSpeed = 0.0f;

	//mouse look
	float yRotation;
	float xRotation;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(LevelController.startGame == true)
		{
			yRotation += Input.GetAxis ("Mouse X");
			xRotation += Input.GetAxis ("Mouse Y");
			transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
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

		rigidbody.AddRelativeForce(Input.GetAxis("Horizontal")*25,0, Input.GetAxis("Vertical")*25);

	}
}
//var turnspeed = 5.0;
//var speed = 5.0;
//private var trueSpeed = 0.0;
//var strafeSpeed = 5.0;

//function Update () {
//	
//	var roll = Input.GetAxis("Roll");
//	var pitch = Input.GetAxis("Pitch");
//	var yaw = Input.GetAxis("Yaw");
//	var strafe = Vector3(Input.GetAxis("Horizontal")*strafeSpeed*Time.deltaTime, Input.GetAxis("Vertical")*strafeSpeed*Time.deltaTime, 0);
//	
//	var power = Input.GetAxis("Power");
//	
//	//Truespeed controls
//	
//	if (trueSpeed < 10 && trueSpeed > -3){
//		trueSpeed += power;
//	}
//	if (trueSpeed > 10){
//		trueSpeed = 9.99;	
//	}
//	if (trueSpeed < -3){
//		trueSpeed = -2.99;	
//	}
//	if (Input.GetKey("backspace")){
//		trueSpeed = 0;
//	}
//	
//	rigidbody.AddRelativeTorque(pitch*turnspeed*Time.deltaTime, yaw*turnspeed*Time.deltaTime, roll*turnspeed*Time.deltaTime);
//	rigidbody.AddRelativeForce(0,0,trueSpeed*speed*Time.deltaTime);
//	rigidbody.AddRelativeForce(strafe);
//}