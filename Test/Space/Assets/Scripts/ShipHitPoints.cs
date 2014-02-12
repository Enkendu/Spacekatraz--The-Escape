using UnityEngine;
using System.Collections;

public class ShipHitPoints : MonoBehaviour {

	// Use this for initialization
	public float hitPoints = 100;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Laser")
		{
			hitPoints -= 5;
		}
	}
}
