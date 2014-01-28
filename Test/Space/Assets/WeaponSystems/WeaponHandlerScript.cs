using UnityEngine;
using System.Collections;

public class WeaponHandlerScript : MonoBehaviour {

	public GameObject projectile;
	public float fireRate = 0.5f;
	float nextFire;
	public float speed = 5.0f;
	// Use this for initialization
	void Start () 
	{
		//fireRate = 0.5;
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fireWeapon();
	}

	void fireWeapon () 
	{
		if(Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject clone = (GameObject)Instantiate(projectile , transform.position, transform.rotation);
			//clone.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,speed));
			clone.rigidbody.velocity = transform.TransformDirection(0,0,speed);
			Physics.IgnoreCollision(clone.collider, transform.root.collider);
		}
	}
}
