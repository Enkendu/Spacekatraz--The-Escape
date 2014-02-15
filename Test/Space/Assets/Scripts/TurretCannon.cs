using UnityEngine;
using System.Collections;

public class TurretCannon : MonoBehaviour {
	public GameObject myProjectile, muzzleEffect;
	private float reloadTime = 1.0f;
	private float turnSpeed = 5.0f;
	private float firePauseTime = .25f;
	private float errorAmount = .001f;
	public Transform myTarget, turretBall;
	public Transform[] muzzlePositions;
	public float projectileSpeed = 70.0f;
	
	private float nextFireTime, nextMoveTime, aimError;
	private Quaternion desiredRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(myTarget)
		{
			if(Time.time>=nextMoveTime)
			{
				CalculateAimPosition(myTarget.position);
				turretBall.rotation = Quaternion.Lerp(turretBall.rotation, desiredRotation, Time.deltaTime*turnSpeed);
			}
			if(Time.time >= nextFireTime)
			{
				FireProjectile();
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="playerShip")
		{
			nextFireTime = Time.time + (reloadTime*.5f);
			myTarget = other.gameObject.transform;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.transform==myTarget)
		{
			myTarget = null;
		}
	}
	
	void CalculateAimPosition(Vector3 targetPos)
	{
		Vector3 aimPoint = new Vector3 (targetPos.x+aimError, targetPos.y+aimError, targetPos.z+aimError);
		desiredRotation = Quaternion.LookRotation(aimPoint);
	}
	
	void CalculateAimError()
	{
		aimError = Random.Range(-errorAmount, errorAmount);
	}
	
	void FireProjectile()
	{
//		audio.Play();
		nextFireTime = Time.time+reloadTime;
		nextMoveTime = Time.time+firePauseTime;
		CalculateAimError();
		foreach(Transform theMuzzlePos in muzzlePositions)
		{
			GameObject projectile = (GameObject)Instantiate(myProjectile, theMuzzlePos.position, theMuzzlePos.rotation);
			projectile.rigidbody.velocity = transform.TransformDirection(0,0,projectileSpeed);
			Physics.IgnoreCollision(projectile.collider, transform.root.collider);
//			Instantiate(muzzleEffect, theMuzzlePos.position, theMuzzlePos.rotation);
		}
	}
}
