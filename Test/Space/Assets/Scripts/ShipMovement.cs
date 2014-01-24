using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	public int shipVelocity = 1;
	
	float yRotation;
	float xRotation;
	
	// Use this for initialization
	void Start ()
	{
		// Lock mouse cursor in game. Press Esc to unlock the cursor
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Mouse look
		yRotation += Input.GetAxis ("Mouse X");
		xRotation += Input.GetAxis ("Mouse Y");
		transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
		
		// Movement
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
	}
}