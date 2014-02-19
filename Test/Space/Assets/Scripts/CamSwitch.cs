using UnityEngine;
using System.Collections;

public class CamSwitch : MonoBehaviour {

	public Camera firstPerson;
	public Camera thirdPerson;
	public GUISkin cockPitView;
	public GUISkin crossHair;
	private bool isFirstPerson = false;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.F1))
		{
			//firstPerson.camera.enabled = true;
			firstPerson.gameObject.SetActive(true);
			//thirdPerson.camera.enabled = false;
			thirdPerson.gameObject.SetActive(false);
			isFirstPerson = true;
		}
		
		if (Input.GetKey(KeyCode.F2))
		{
			//firstPerson.camera.enabled = false;
			firstPerson.gameObject.SetActive(false);
			//thirdPerson.camera.enabled = true;
			thirdPerson.gameObject.SetActive(true);
			isFirstPerson = false;

		}
	}

	void OnGUI()
	{
		if(isFirstPerson == true)
		{
			GUI.skin = cockPitView;
			GUI.Box(new Rect(0.0f, 0.0f, Screen.width, Screen.height), " ");
		}

		if(isFirstPerson == false)
		{
			GUI.skin = crossHair;
			GUI.Box (new Rect((Screen.width/2) - 15.0f, (Screen.height/2) - 70.0f, 30.0f, 30.0f), " ");
		}
	}
}
