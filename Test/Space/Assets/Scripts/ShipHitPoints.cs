using UnityEngine;
using System.Collections;


//[RequireComponent (typeof (AudioClip))]
[RequireComponent(typeof(AudioSource))]
public class ShipHitPoints : MonoBehaviour {

	// Use this for initialization

	public GameObject mainCamera;
	public GameObject explosion;

	public float hitPoints = 100;
	public AudioClip shipExplosionSound;

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
			print (hitPoints);
		}

		if (hitPoints <= 0.0f)
		{
			if(mainCamera != null)
			{
				mainCamera.transform.parent = null;
			}
			if(transform.tag == "playerShip")
			{
				//print (transform.tag);
				LevelController.didDie = true;
			}

			//audio.PlayOneShot(shipExplosionSound, 5.0f);
			//audio.Play();
			SpawnExplosions();
			Destroy(gameObject);
		}
	}

	void SpawnExplosions()
	{
		//add instantiate explosion here.
		GameObject clone = (GameObject)Instantiate(explosion , transform.position, transform.rotation);
		//clone.AddComponent("AudioSource") as AudioSource;

//		clone.AddComponent<AudioSource>();
		//		clone.clip = Resources.Load(shipExplosionSound) as AudioClip;
//		audioSource.Play();

		//clone.transform.audio.Play ();
	}
}
