using UnityEngine;
using System.Collections;


//[RequireComponent (typeof (AudioClip))]

public class ShipHitPoints : MonoBehaviour {

	// Use this for initialization

	public GameObject mainCamera;
	public GameObject firstPersonCamera;
	public GameObject explosion;
	public GameObject shipExplosionSound;
	public AudioClip shipHit;
	public AudioClip scream;

	public float hitPoints = 100;
	private bool canDestroy;

	void Start () {
		canDestroy = true;
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Laser")
		{
			hitPoints -= 5;
			audio.clip = shipHit;
			audio.Play ();
			//print (hitPoints);
		}

		if (hitPoints <= 0.0f && canDestroy == true)
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

			if(canDestroy == true)
			{
				SpawnExplosions();
			}
			canDestroy = false;
		}


	}

	void SpawnExplosions()
	{
		Instantiate(explosion , transform.position, transform.rotation);
		Instantiate(shipExplosionSound , transform.position, transform.rotation);

		if(audio.isPlaying)
		{
			audio.Stop();
		}

		if(scream != null)
		{
			audio.clip = scream;
			audio.Play();
		}

		Destroy(gameObject , 1.0f);
	}
}
