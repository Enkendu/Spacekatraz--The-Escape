using UnityEngine;
using System.Collections;


public class TurretCannonNew : MonoBehaviour {
	// Variables used to target the player
	private GameObject player;
	private int viewDistance = 300;
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
			}
		}
	}

}
