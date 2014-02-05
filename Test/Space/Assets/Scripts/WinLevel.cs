using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {

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
			LevelController.didWin = true;
			print ("Got hit by" + other.transform.name);
		}
	}
		
}
