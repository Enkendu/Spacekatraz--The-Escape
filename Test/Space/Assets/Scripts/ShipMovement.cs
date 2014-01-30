using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
//<<<<<<< HEAD
	public int shipVelocity = 1;
//=======
	//public float shipVelocity = 5.0f;
//>>>>>>> origin/Nathan
	
	float yRotation;
	float xRotation;
	
	// Use this for initialization
	void Start ()
	{
		// Lock mouse cursor in game. Press Esc to unlock the cursor
		//Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Mouse look
		if(LevelController.startGame == true)
		{
			yRotation += Input.GetAxis ("Mouse X");
			xRotation += Input.GetAxis ("Mouse Y");
			transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
		}
		// Movement
//<<<<<<< HEAD
		if (Input.GetAxis ("Vertical") > 0)
			transform.Translate(0, 0, shipVelocity);
		
		if (Input.GetAxis ("Vertical") < 0)
			transform.Translate(0, 0, -shipVelocity);
		
		if (Input.GetAxis ("Horizontal") < 0)
			transform.Translate (-shipVelocity, 0, 0);
		
		if (Input.GetAxis ("Horizontal") > 0)
			transform.Translate (shipVelocity, 0, 0);

		if (Input.GetAxis ("Jump") > 0)
			transform.Translate (0, shipVelocity, 0);

		if (Input.GetAxis ("Crouch") > 0)
			transform.Translate (0, -shipVelocity, 0);
//=======
		if (Input.GetAxis ("Vertical") > 0) 
		{
			transform.position += transform.forward * shipVelocity * Time.deltaTime;
			//transform.Translate(0, shipVelocity, 0 * Time.deltaTime);
		}
		
		if (Input.GetAxis ("Vertical") < 0) 
		{
			transform.position -= transform.forward * shipVelocity * Time.deltaTime;
			//transform.Translate(0, -shipVelocity, 0 * Time.deltaTime);
		}
		
		if (Input.GetAxis ("Horizontal") < 0) 
		{
			transform.Translate (-shipVelocity * Time.deltaTime, 0, 0);
			//transform.Translate (-shipVelocity, 0, 0 * Time.deltaTime);
		}
		
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			transform.Translate (shipVelocity * Time.deltaTime, 0, 0);
			//transform.Translate (shipVelocity, 0, 0 * Time.deltaTime);
		}
//>>>>>>> origin/Nathan
	}
}