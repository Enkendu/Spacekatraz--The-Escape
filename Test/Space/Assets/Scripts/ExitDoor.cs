using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {


	bool reactorOneDestroyed;
	bool reactorTwoDestroyed;
	// Use this for initialization
	void Start () {
		reactorOneDestroyed = false;
		reactorTwoDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(reactorOneDestroyed == true && reactorTwoDestroyed == true)
		{
			print ("Door is opened");
			Destroy(gameObject);
		}
	
	}

	void DestroyReactorOne()
	{
		reactorOneDestroyed = true;
	}

	void DestroyReactorTwo()
	{
		reactorTwoDestroyed = true;
	}
}
