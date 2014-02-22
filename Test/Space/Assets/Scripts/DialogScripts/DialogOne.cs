using UnityEngine;
using System.Collections;

public class DialogOne : MonoBehaviour {

	// Use this for initialization
	bool showDialog;
	float dialogTimer = 0.0f;
	public float dialogTime = 9.0f;

	void Start () {
	
	}
	
	// Update is called once per frame
//	void Update () {
//
//	
//	}

	void OnTriggerEnter(Collider other)
	{
//		print (" other is " + other);
//		print (" other transform name is " + other.transform.name);
//		print ("other transform tag is " + other.transform.tag);
		if(other.transform.tag == "playerShip")
		{
			LevelController.dialogOne = true;

		}
	}
}
