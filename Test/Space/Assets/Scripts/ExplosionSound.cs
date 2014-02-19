using UnityEngine;
using System.Collections;

public class ExplosionSound : MonoBehaviour {

	// Use this for initialization
	float blowUp = 5.0f;
	public AudioClip explosionSound;
	void Start () {
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//audio.Play ();
		if(!audio.isPlaying)
		{
			//audio.Play();
//			if(Time.time > blowUp)
//			{
				Destroy(gameObject, 1.0f);
//			}
		}
	}


}
