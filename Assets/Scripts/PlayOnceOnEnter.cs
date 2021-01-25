using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnceOnEnter : MonoBehaviour {

	public AudioClip enterSound;

	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider coll)
	{	       
		//Debug.Log("Player Object Entered Target Area");
        audio.PlayOneShot(enterSound);
	}

	void OnTriggerExit(Collider coll)
	{
		//Debug.Log("Player Object Exited Target Area");
	}

}