using UnityEngine;
using System.Collections;


[RequireComponent (typeof (AudioClip))]
public class EnemyShipAI : MonoBehaviour {
	// Variables used to target the player
	private GameObject player;
	private int viewDistance = 300;
	private int stopDistance = 100;
	private float gapDistance;

	// Movement variables	
	private float power = 1.0F;
	private float trueSpeed = 0.0f;


	// weapon fire variables
	public GameObject projectile;
	public float fireRate = 0.5f;
	float nextFire;
	public float speed = 5.0f;
	Material material;
	public float damage = 10;
	//sound for laser fire
	public AudioClip laserSound;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("playerShip");
		nextFire = Time.time;
		material = new Material(Shader.Find("Diffuse"));
	}

	
	// Update is called once per frame
	void Update () 
	{
		gapDistance = Vector3.Distance (this.transform.position, player.transform.position);


		if (gapDistance <= viewDistance) 
		{
			transform.LookAt(player.transform.position);
			if(LevelController.canFire == true && LevelController.pause == false)
			{
				fireWeapon();
			}

			if(gapDistance > stopDistance)
			{
				//Truespeed controls
				
				if (trueSpeed < 10 && trueSpeed > -3)
				{
					trueSpeed += power;
				}
				if (trueSpeed > 10)
				{
					trueSpeed = 9.99f;	
				}
				if (trueSpeed < -3)
				{
					trueSpeed = -2.99f;	
				}
				if (Input.GetKey("backspace"))
				{
					trueSpeed = 0;
				}

				rigidbody.AddRelativeForce(Vector3.forward*25);
			}

		}
	}

	void fireWeapon()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			GameObject newClone = (GameObject)Instantiate(projectile, this.transform.position,this.transform.rotation);
			material.color = new Color (1, 0, 0, 0);
			newClone.renderer.material = material;
			newClone.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,speed));
			Physics.IgnoreCollision (newClone.collider, transform.root.collider);
			audio.PlayOneShot(laserSound, 5.0f);
		}
	}

}
