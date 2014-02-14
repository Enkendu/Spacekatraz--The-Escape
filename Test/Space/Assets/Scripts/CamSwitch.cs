using UnityEngine;
using System.Collections;

public class CamSwitch : MonoBehaviour {

	public Camera firstPerson;
	public Camera thirdPerson;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.F1))
		{
			firstPerson.camera.enabled = true;
			thirdPerson.camera.enabled = false;
		}
		
		if (Input.GetKey(KeyCode.F2))
		{
			firstPerson.camera.enabled = false;
			thirdPerson.camera.enabled = true;
		}
	}
}
