using UnityEngine;
using System.Collections;

public class RandomAudtioClipSelector : MonoBehaviour
{
	public AudioClip[] clips;
	public AudioSource audiosource;

	void Start()
	{
		audiosource.clip = clips[Random.Range(0, clips.Length)];
		audiosource.Play();
	}
	
}
