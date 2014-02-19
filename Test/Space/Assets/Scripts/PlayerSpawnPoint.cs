using UnityEngine;
using System.Collections;

public class PlayerSpawnPoint : MonoBehaviour {

	public GameObject playerShip;
	public static float playerHP;
	GameObject clone;
	// Use this for initialization
	void Start () {
		clone = (GameObject)Instantiate(playerShip, transform.position, transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		playerHP = clone.GetComponent<ShipHitPoints>().hitPoints;
	}
}
