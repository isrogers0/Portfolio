using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject pinPrefab;
	public AudioSource audioSource;
	public AudioClip clip;

	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			SpawnPin();
		}
	}

	void SpawnPin ()
	{
		audioSource.PlayOneShot(clip, 0.5f);
		Instantiate(pinPrefab, transform.position, transform.rotation);
	}

}
