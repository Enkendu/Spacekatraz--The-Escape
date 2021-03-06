﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioClip))]
public class TurretBarrelFire : MonoBehaviour {
	
	// Variables used to target the player
	private GameObject player;
	private int viewDistance = 300;
	private float gapDistance;

	// weapon fire variables
	public GameObject projectile;
	public float fireRate = 0.5f;
	float nextFire;
	public float speed = 50.0f;
	Material material;
	public float damage = 10;

	//sound for laser fire
	public AudioClip laserSound;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("playerShip");
		nextFire = Time.time;
		material = new Material(Shader.Find("Diffuse"));	
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
		{
			gapDistance = Vector3.Distance (this.transform.position, player.transform.position);

			if (gapDistance <= viewDistance) 
			{
				if(LevelController.canFire == true && LevelController.pause == false)
				{
					fireWeapon();
				}
			}
		}
	
	}
	
	void fireWeapon()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			GameObject newClone = (GameObject)Instantiate(projectile,this.transform.position, transform.rotation);
			Physics.IgnoreCollision (newClone.collider, transform.collider);
			Physics.IgnoreCollision (newClone.collider, transform.parent.collider);
			newClone.transform.Rotate(90,0,0);
			newClone.transform.localScale = newClone.transform.localScale*4;
			material.color = new Color (0, 1, 0, 0);
			newClone.renderer.material = material;
			newClone.rigidbody.velocity = transform.TransformDirection(transform.forward*-speed);

			audio.PlayOneShot(laserSound, 1.0f);

		}
	}
}
