using UnityEngine;
using System.Collections;

public class SpaceShipMovement : MonoBehaviour {

	// Use this for initialization
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
		if(LevelController.startGame == true || Screen.lockCursor == true)
		{
			yRotation += Input.GetAxis ("Mouse X");
			xRotation += Input.GetAxis ("Mouse Y");
			ZRotation += Input.GetAxis ("Roll");
			transform.rotation = Quaternion.Euler (xRotation, yRotation, ZRotation);
		}

		rigidbody.AddRelativeForce(Input.GetAxis("Horizontal")*shipSpeed, Input.GetAxis("Updown")*shipSpeed, Input.GetAxis("Vertical")*shipSpeed);
	}
}

