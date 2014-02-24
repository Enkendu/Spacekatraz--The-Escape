using UnityEngine;
using System.Collections;

public class Reactor : MonoBehaviour {

	// Use this for initialization
	public GameObject exitDoor;
	public GameObject forceField;
	public float reactorHitPoints = 300.0f;
	public GameObject reactorExplosionSound;
	public GameObject reactorExplosionEFX;
	public bool reactorOne;
	public bool reactorTwo;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if(reactorHitPoints <= 0.0f)
		{
			Instantiate(reactorExplosionEFX , transform.position, transform.rotation);
			GameObject clone = (GameObject)Instantiate(reactorExplosionSound , transform.position, transform.rotation);
			Destroy(gameObject);
			print ("Destroy" + transform.name.ToString());
			exitDoor.SendMessage("Destroy" + transform.name.ToString(),SendMessageOptions.DontRequireReceiver);
			if(reactorOne == true)
			{
				LevelController.dialogTwo = true;
			}
			if(reactorTwo == true)
			{
				LevelController.dialogThree = true;
			}
		}
		if(forceField == null && collision.transform.tag == "Laser")
		{
			reactorHitPoints -= 20;
		}
	}
}
