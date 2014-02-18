using UnityEngine;
using System.Collections;


//[RequireComponent (typeof (AudioClip))]
[RequireComponent(typeof(AudioSource))]
public class ShipHitPoints : MonoBehaviour {

	// Use this for initialization

	public GameObject mainCamera;
	public GameObject firstPersonCamera;
	public GameObject explosion;
	public GameObject shipExplosionSound;

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
			//print (hitPoints);
		}

		if (hitPoints <= 0.0f)
		{
			if(mainCamera != null)
			{
				mainCamera.transform.parent = null;
			}
			if(firstPersonCamera != null)
			{
				firstPersonCamera.transform.parent = null;
			}
			if(transform.tag == "playerShip")
			{
				//print (transform.tag);
				LevelController.didDie = true;
			}

			SpawnExplosions();
			Destroy(gameObject);
		}
	}

	void SpawnExplosions()
	{
		//add instantiate explosion here.
		Instantiate(explosion , transform.position, transform.rotation);
		GameObject clone = (GameObject)Instantiate(shipExplosionSound , transform.position, transform.rotation);
	}
}
