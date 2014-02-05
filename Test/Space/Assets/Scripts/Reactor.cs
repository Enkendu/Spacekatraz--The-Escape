using UnityEngine;
using System.Collections;

public class Reactor : MonoBehaviour {

	// Use this for initialization
	public GameObject exitDoor;
	public float reactorHitPoints = 300.0f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if(reactorHitPoints <= 0.0f)
		{
			Destroy(gameObject);
			print ("Destroy" + transform.name.ToString());
			exitDoor.SendMessage("Destroy" + transform.name.ToString(),SendMessageOptions.DontRequireReceiver);
		}
		reactorHitPoints -= 20;
	}
}
