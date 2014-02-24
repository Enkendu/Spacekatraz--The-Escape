using UnityEngine;
using System.Collections;

public class DialogFour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "playerShip")
		{
			LevelController.dialogFour = true;
		}
	}
}
