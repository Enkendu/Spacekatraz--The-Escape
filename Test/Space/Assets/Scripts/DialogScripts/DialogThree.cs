﻿using UnityEngine;
using System.Collections;

public class DialogThree : MonoBehaviour {

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
			LevelController.dialogThree = true;
			
		}
	}
}