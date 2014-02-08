using UnityEngine;
using System.Collections;

//[RequireComponent(typeof("Laser"))]
[RequireComponent (typeof (AudioClip))]
public class WeaponHandlerScript : MonoBehaviour {

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
		nextFire = Time.time;
		material = new Material(Shader.Find("Diffuse"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LevelController.canFire == true)
		{
			fireWeapon();
		}
	}

	void fireWeapon () 
	{
		if(Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject clone = (GameObject)Instantiate(projectile , transform.position, transform.rotation);
			//clone.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,speed));
			material.color = new Color(1,0,0,0);
			clone.renderer.material = material;
			clone.rigidbody.velocity = transform.TransformDirection(0,0,speed);
			Physics.IgnoreCollision(clone.collider, transform.root.collider);
			audio.PlayOneShot(laserSound, 1.0f);

		}
	}


}
