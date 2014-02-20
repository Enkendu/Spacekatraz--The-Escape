using UnityEngine;
using System.Collections;

public class ReactorForceFields : MonoBehaviour {

	// Use this for initialization

	public GameObject turretOne;
	public GameObject turretTwo;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(turretOne == null && turretTwo == null)
		{
			Destroy(gameObject);
		}
	
	}
}
