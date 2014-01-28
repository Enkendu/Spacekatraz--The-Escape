using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	public float shipVelocity = 5.0f;
	
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
	}
}