using UnityEngine;
using System.Collections;

public class ExitForceField : MonoBehaviour {
	
	// Use this for initialization
	
	public GameObject bossShip;

	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(bossShip == null)
		{
			Destroy(gameObject);
		}
		
	}
}
