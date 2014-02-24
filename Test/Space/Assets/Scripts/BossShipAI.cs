using UnityEngine;
using System.Collections;

public class BossShipAI : MonoBehaviour {
	// Variables used to target the player
	private GameObject player;
	private int viewDistance = 500;
	private int stopDistance = 150;
	private float gapDistance;
	
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("playerShip");
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(player != null)
		{
			gapDistance = Vector3.Distance (this.transform.position, player.transform.position);
			
			
			if (gapDistance <= viewDistance) 
			{
				transform.LookAt(player.transform.position);
				
				if(gapDistance > stopDistance)
				{
					rigidbody.AddRelativeForce(Vector3.forward*25);
				}
			}
		}
	}

}
